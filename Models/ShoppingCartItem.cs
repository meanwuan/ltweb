namespace THweb.Models
{
    public class ShoppingCartItem
    {
        public int ID { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public string? ShoppingCartId { get; set; }
    }
}
