using Microsoft.AspNetCore.Mvc;

namespace mvc_5.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
