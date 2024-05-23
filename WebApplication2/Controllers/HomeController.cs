using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Slider slider = new Slider()
            {
                Id = 1,
                Name = "Test1",
                Description = "Yeni1",
                PhotoUrl="service-3.jpg"
            };
            Slider slider2 = new Slider()
            {
                Id = 2,
                Name = "Test2",
                Description = "Yeni2",
                PhotoUrl = "service-4.jpg"


            };
      
            List<Slider> sliders = new List<Slider>();
            sliders.Add(slider);
            sliders.Add(slider2);

            return View(sliders);
        }
    }
}
