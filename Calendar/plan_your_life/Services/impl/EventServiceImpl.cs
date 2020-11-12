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
            Event eventToSave = _context.Event.Add(e);
            _context.SaveChanges();
            return eventToSave;
        }

        public Event FindById(long id)
        {
            return _context.Event.First(p => p.Id == id);
        }

        public IEnumerable<Event> FindAll()
        {
            return _context.Event.ToList();
        }

        public void DeleteById(long id)
        {
            _context.Event.Remove(FindById(id));
            _context.SaveChanges();
        }

        public Event Update(Event e)
        {
            Event eventToUpdate = FindById(e.Id);
            eventToUpdate.Name = e.Name;
            eventToUpdate.Description = e.Description;
            eventToUpdate.StartAt = e.StartAt;
            eventToUpdate.EndAt = e.EndAt;
            _context.Entry(eventToUpdate).State = EntityState.Modified;
            _context.SaveChanges();
            return eventToUpdate;
        }
    }
}