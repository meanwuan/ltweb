namespace THweb.Models.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetTrenddingProduct();
        Product GetProductDetail(int id);
    }
}
