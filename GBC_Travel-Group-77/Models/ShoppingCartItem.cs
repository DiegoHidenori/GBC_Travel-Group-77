namespace GBC_Travel_Group_77.Models
{
    public class ShoppingCartItem
    {
        public int shoppingCartItemId { get; set; }
        public int itemId { get; set; }
        public int number { get; set; }

        public string type { get; set; }
        public string? shoppingCartId { get; set; }
    }
}
