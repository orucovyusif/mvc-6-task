using Microsoft.AspNetCore.Mvc;

namespace mvc__bilet_5.Areas.Manage.Controllers
{
	[Area("Manage")]
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
