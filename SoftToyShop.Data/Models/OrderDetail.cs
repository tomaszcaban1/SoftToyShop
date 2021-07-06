namespace SoftToyShop.Repository.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int SoftToyId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public virtual SoftToy SoftToy { get; set; }
        public virtual Order Order { get; set; }
    }
}