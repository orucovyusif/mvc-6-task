using Microsoft.AspNetCore.Mvc;
using mvc__bilet_5.Data;
using mvc__bilet_5.Models;

namespace mvc__bilet_5.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DesignController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _environment;

        public AppDbContext Context { get; set; }
        public DesignController(AppDbContext appDbContext, IWebHostEnvironment environment)
        {
            _appDbContext = appDbContext;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View(_appDbContext.Designs.ToList());
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Designs designs)
        {
            if (!ModelState.IsValid) { return View(); }
            if (!designs.ImgFile.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("ImgFile", "Duzgun daxil edin");
            }

            string path = _environment.WebRootPath + @"\Upload\";
            string filename = Guid.NewGuid() + designs.ImgFile.FileName;
            using (FileStream stream = new FileStream(path + filename, FileMode.Create))
            {
                designs.ImgFile.CopyTo(stream);
            }
            designs.ImgUrl = filename;
            _appDbContext.Designs.Add(designs);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var designs = _appDbContext.Designs.FirstOrDefault(x => x.Id == id);
            if (designs == null)
            {
                return RedirectToAction("Index");
            }
            return View(designs);
        }
        [HttpPost]

        public IActionResult Update(Designs newDesign)
        {
            var oldDesign = _appDbContext.Designs.FirstOrDefault(x => x.Id == newDesign.Id);

            if (oldDesign == null) return NotFound();
            if (!ModelState.IsValid)
            {
                return View(oldDesign);
            }
            
            if(newDesign.ImgFile != null)
            {
                string path = _environment.WebRootPath + @"\Upload\";
                string filename = Guid.NewGuid() + newDesign.ImgFile.FileName;
                using (FileStream stream = new FileStream(path + filename, FileMode.Create))
                {
                    newDesign.ImgFile.CopyTo(stream);
                }
                oldDesign.ImgUrl = filename;
            }
            oldDesign.Name=newDesign.Name;
            oldDesign.Description=newDesign.Description;
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            var design = _appDbContext.Designs.FirstOrDefault(x => x.Id == id);
            if (design == null) return NotFound();
            _appDbContext.Designs.Remove(design);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
