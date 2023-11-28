using Microsoft.EntityFrameworkCore;
using System.IO.Pipelines;

namespace ProjectShopMVC.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly ProjectDbContext _projectDbContext;

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        private ShoppingCart(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            ProjectDbContext context = services.GetService<ProjectDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Project project)
        {
            var shoppingCartItem =
                    _projectDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Project.ProjectId == project.ProjectId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Project = project,
                    Amount = 1
                };

                _projectDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _projectDbContext.SaveChanges();
        }

        public int RemoveFromCart(Project project)
        {
            var shoppingCartItem =
                    _projectDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Project.ProjectId == project.ProjectId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _projectDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _projectDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
                       _projectDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                          .Include(s => s.Project)
                           .ToList();
        }

        public void ClearCart()
        {
            var cartItems = _projectDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _projectDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _projectDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _projectDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Project.Price * c.Amount).Sum();
            return total;
        }
    }
}
