namespace SoftToyShop.Repository.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public SoftToy SoftToy { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
