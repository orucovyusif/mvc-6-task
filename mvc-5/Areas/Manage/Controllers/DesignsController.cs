using Microsoft.AspNetCore.Mvc;
using mvc_5.Data;
using mvc_5.Models;

namespace mvc_5.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DesignsController : Controller
    {
        private readonly AppDbContext _context;

        public DesignsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Portfolio.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(Portfolio portfolio)
        {
            return View();
        }
    }
}
