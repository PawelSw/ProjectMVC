namespace ProjectShopMVC.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ProjectDbContext _projectDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(ProjectDbContext projectDbContext, IShoppingCart shoppingCart)
        {
            _projectDbContext = projectDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    ProjectId = shoppingCartItem.Project.ProjectId,
                    Price = shoppingCartItem.Project.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _projectDbContext.Orders.Add(order);

            _projectDbContext.SaveChanges();
        }
    }
}
