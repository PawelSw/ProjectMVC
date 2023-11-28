using System.IO.Pipelines;

namespace ProjectShopMVC.Models
{
    public interface IShoppingCart
    {
        void AddToCart(Project project);
        int RemoveFromCart(Project project);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
