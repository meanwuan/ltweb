using System.Diagnostics;
using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc;
using THweb.Models;
using THweb.Models.Interfaces;

namespace THweb.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository productReporisory;

        public HomeController(IProductRepository productReporisory)
        {
            this.productReporisory = productReporisory;
        }

        public IActionResult Index()
        {
            return View(productReporisory.GetTrenddingProduct());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
