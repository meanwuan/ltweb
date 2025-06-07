namespace THweb.Models
{
    public class Orderdetail
    {
        public int Id { get; set; }
        public int productId { get; set; }
        public Product? Product { get; set; }
        public int orderId { get; set; }
        public order? Order { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
    }
}