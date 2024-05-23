using Microsoft.AspNetCore.Mvc;

namespace Full_task.Areas.Manage.Controllers
{
    public class HospitalController : Controller
    {
        [Area("Manage")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
