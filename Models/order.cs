namespace THweb.Models
{
    public class order
    {
        public int Id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? address { get; set; }
        public decimal total { get; set; }
        public DateTime createdAt { get; set; }
        public List<Orderdetail>? orderdetails  { get; set; }
    }
}
