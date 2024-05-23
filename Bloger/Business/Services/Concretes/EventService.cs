using Business.Exceptions;
using Business.Extensions;
using Business.Services.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concretes;

public class EventService : IEventService
{
	private readonly IEventRepository _eventRepository;
	private readonly IWebHostEnvironment _env;

	public EventService(IEventRepository eventRepository, IWebHostEnvironment env)
	{
		_eventRepository = eventRepository;
		_env = env;
	}

	public async Task AddEvent(Event evn)
	{
		if (evn.ImageFile == null) throw new FileRequiredException("Image is required");

		evn.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/events", evn.ImageFile);

		await _eventRepository.AddEntityAsync(evn);
		await _eventRepository.CommitAsync();
	}

	public void DeleteEvent(int id)
	{
		var existEvent = _eventRepository.GetEntity(x=> x.Id == id);
		if (existEvent == null) throw new EntityNotFoundException("Event tapilmadi");

		Helper.DeleteFile(_env.WebRootPath, @"uploads/events", existEvent.ImageUrl);

		_eventRepository.DeleteEntity(existEvent);
		_eventRepository.Commit();
	}

	public List<Event> GetAllEvents(Func<Event, bool>? func = null)
	{
		return _eventRepository.GetAllEntities(func);
	}

	public Event GetEvent(Func<Event, bool>? func = null)
	{
		return _eventRepository.GetEntity(func);
	}

	public void UpdateEvent(Event evn)
	{
		var oldEvent = _eventRepository.GetEntity(x => x.Id == evn.Id);
		if (oldEvent == null) throw new EntityNotFoundException("Event tapilmadi");

		if(evn.ImageFile != null)
		{
			evn.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/events", evn.ImageFile);
			Helper.DeleteFile(_env.WebRootPath, @"uploads/events", oldEvent.ImageUrl);

			oldEvent.ImageUrl = evn.ImageUrl;

		}

		oldEvent.Title = evn.Title;
		oldEvent.Description = evn.Description;

		_eventRepository.Commit();

	}
}
