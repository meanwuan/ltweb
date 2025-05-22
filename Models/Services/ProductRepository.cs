using Microsoft.AspNetCore.Mvc;
using THweb.Models.Interfaces;
using THweb.data;

namespace THweb.Models.Services
{

    public class ProductRepository : IProductRepository
    {
        private CoffeShopDbcontext dbcontext;
        public ProductRepository(CoffeShopDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return dbcontext.Products;
        }
        public Product? GetProductDetail(int id)
        { 
            return dbcontext.Products.FirstOrDefault(p => p.ID == id);
        }
        public IEnumerable<Product> GetTrenddingProduct()
        {
            return dbcontext.Products.Where(p => p.istrendingproduct);
        }
    }
}
