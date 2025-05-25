using BuyEasy.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BuyEasy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); // Show landing page
        }

        public IActionResult About()
        {
            return View(); // About Us page
        }

        public IActionResult Contact()
        {
            return View(); // ContactViewModel Us page
        }
    }
}
