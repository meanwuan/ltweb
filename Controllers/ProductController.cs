using Microsoft.AspNetCore.Mvc;
using THweb.Models.Interfaces;

namespace THweb.Controllers
{
    public class ProductController : Controller
    {
       private IProductRepository productReporisoty;

        public ProductController(IProductRepository productReporisoty)
        {
            this.productReporisoty = productReporisoty;
        }
        public IActionResult Shop()
        {
            return View(productReporisoty.GetAllProducts());
        }
        public IActionResult Details(int id)
        {
            var product = productReporisoty.GetProductDetail(id);
            if (product != null)
            {
                return View(product);
               
            }
            return NotFound();
        }
    }
}
