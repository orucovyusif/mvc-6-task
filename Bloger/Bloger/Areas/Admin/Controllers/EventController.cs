using Business.Exceptions;
using Business.Services.Abstracts;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Bloger.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class EventController : Controller
	{
		private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult Index()
		{
			var events = _eventService.GetAllEvents();
			return View(events);
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Event evn)
		{
			if (!ModelState.IsValid)
				return View();

			try
			{
				await _eventService.AddEvent(evn);
			}
			catch (FileRequiredException ex)
			{

				ModelState.AddModelError("ImageFile",ex.Message);
				return View();
			}
            catch (FileContentTypeException ex)
            {

                ModelState.AddModelError("ImageFile", ex.Message);
				return View();
            }
            catch (FileSizeException ex)
            {

                ModelState.AddModelError("ImageFile", ex.Message);
				return View();
            }
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return RedirectToAction("Index");

        }
		public IActionResult Update(int id) 
		{
			var existEvent = _eventService.GetEvent(x => x.Id == id);
			if (existEvent == null) return NotFound();


			return View(existEvent);
				
		}
		[HttpPost]
		public IActionResult Update(Event evn)
		{
            
            if (!ModelState.IsValid)
                return View();

            try
            {
                _eventService.UpdateEvent(evn);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (EntityFileNotFoundException ex)
            {
                return NotFound();
            }
            catch (FileContentTypeException ex)
            {

                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (FileSizeException ex)
            {

                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            var existEvent = _eventService.GetEvent(x => x.Id == id);
            if (existEvent == null) return NotFound();


            return View(existEvent);

        }
        [HttpPost]
        public IActionResult DeletePost(int id) 
        {
            var existEvent = _eventService.GetEvent(x => x.Id == id);
            if (existEvent == null) return NotFound();

            try
            {
                _eventService.DeleteEvent(id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (EntityFileNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
