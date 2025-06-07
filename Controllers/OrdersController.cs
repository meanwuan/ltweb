using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using THweb.Models;
using THweb.Models.Interfaces;
using THweb.Models.Services;
namespace THweb.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private IorderRespository orderRepository;
        private IShoppingCartRepository shoppingCartRepository;
        public OrdersController(IorderRespository orderRepository, IShoppingCartRepository shoppingCartRepository)
        {
            this.orderRepository = orderRepository;
            this.shoppingCartRepository = shoppingCartRepository;
        }
        public IActionResult checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult checkout(order order)
        {
            if (ModelState.IsValid)
            {
                orderRepository.placeOrder(order);
                shoppingCartRepository.ClearCart();
                HttpContext.Session.SetInt32("CartCount", 0);
                return RedirectToAction("complete");
            }
            return RedirectToAction("checkoutcomplete");
        }
        public IActionResult checkoutcomplete()
        {
            return View();
        }
    } 
}
