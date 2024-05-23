using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bloger.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles ="SuperAdmin")]
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
