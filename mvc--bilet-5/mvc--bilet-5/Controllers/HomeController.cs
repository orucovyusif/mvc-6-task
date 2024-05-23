using Microsoft.AspNetCore.Mvc;
using mvc__bilet_5.Data;
using System.Diagnostics;

namespace mvc__bilet_5.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
		{

			return View(_context.Designs.ToList());
		}

		
	}
}