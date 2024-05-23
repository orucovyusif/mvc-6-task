using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstracts;

public interface IEventService
{
	Task AddEvent(Event evn);
	void DeleteEvent(int id);
	void UpdateEvent(Event evn);
	Event GetEvent(Func<Event, bool>? func = null);
	List<Event> GetAllEvents(Func<Event, bool>? func = null);
}
