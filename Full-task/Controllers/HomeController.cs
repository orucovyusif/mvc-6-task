using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Full_task.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

    }
}