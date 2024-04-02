namespace GBC_Travel_Group_77.Models
{
    public interface IShoppingCart
    {
        void AddToCart(int id, int number, string type);

        //int RemoveFromCart(IShoppingCartItem item);

        List<ShoppingCartItem> GetShoppingCartItems();

        void ClearCart();

        //decimal GetShoppingCartTotal(); // changed from decimal to double because of errors in ShoppingCart.cs

        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
