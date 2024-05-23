using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace mvc_5.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }

       
    }
}