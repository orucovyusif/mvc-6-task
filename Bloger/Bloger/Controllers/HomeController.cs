using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bloger.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }

    }
}