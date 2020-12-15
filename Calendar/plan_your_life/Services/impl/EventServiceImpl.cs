using System.Collections.Generic;
using System.Linq;
using Calendar.plan_your_life.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calendar.plan_your_life.Services.impl
{
    public class EventServiceImpl : EventService
    {
        private Context _context;

        public EventServiceImpl(Context context)
        {
            _context = context;
        }

        public Event Save(Event e)
        {
            var eventToSave = _context.Events.Add(e);
            _context.SaveChanges();

            return eventToSave.Entity;
        }

        public Event FindById(long id)
        {
            return _context.Events.First(p => p.Id == id);
        }

        public IEnumerable<Event> FindAll()
        {
            return _context.Events.ToList();
        }

        public void DeleteById(long id)
        {
            Event eventt = FindById(id);
            _context.Events.Remove(eventt);
            _context.SaveChanges();
        }

        public Event Update(Event e)
        {
            Event eventToUpdate = FindById(e.Id);
            eventToUpdate.Name = e.Name;
            eventToUpdate.Description = e.Description;
            eventToUpdate.StartAt = e.StartAt;
            eventToUpdate.EntAt = e.EntAt;
            _context.Entry(eventToUpdate).State = EntityState.Modified;
            _context.SaveChanges();
            return eventToUpdate;
        }

        public IEnumerable<Event> FindAllByUserId(long userId)
        {
            return _context.UserEvents
                 .Where(u => u.User.Id == userId).Select(g => g.Event).ToList();
        }

        public void Save(Event e, long userId)
        {
            User user = _context.Users.First(p => p.Id == userId);

            var userEvent = new UserEvent();
            userEvent.Event = e;
            userEvent.User = user;
            _context.UserEvents.Add(userEvent);
            _context.Events.Add(e);
            _context.SaveChanges();

        }
    }
}