using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using THweb.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using THweb.Models.Interfaces;
namespace THweb.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IShoppingCartRepository shoppingCartRepository;
        private IProductRepository productRepository;
        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
        }
        public IActionResult Index()
        {
           var items = shoppingCartRepository.GetAllShoppingCartItems();
            shoppingCartRepository.ShoppingCartItems = items;
            ViewBag.Total = shoppingCartRepository.GetShoppingCartTotal();
            return View(items);
        }
        public RedirectToActionResult AddToShoppingCart(int pid)
        {
            var product = productRepository.GetAllProducts().FirstOrDefault(p => p.ID == pid);
            if (product != null)
            {
                shoppingCartRepository.AddToCart(product);
                int cartCount = shoppingCartRepository.GetAllShoppingCartItems().Count();
                HttpContext.Session.SetInt32("CartCount", cartCount);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int pid)
        {
           var product = productRepository.GetAllProducts().FirstOrDefault(p => p.ID == pid);
            if (product != null)
            {
                shoppingCartRepository.RemoveFromCart(product);
                int cartCount = shoppingCartRepository.GetAllShoppingCartItems().Count();
                HttpContext.Session.SetInt32("CartCount", cartCount);
            }
            return RedirectToAction("Index");
        }
    }
}
