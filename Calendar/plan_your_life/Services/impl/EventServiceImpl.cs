using System.Collections.Generic;
using System.Linq;
using Calendar.plan_your_life.Entities;

namespace Calendar.plan_your_life.Services.impl
{
    public class EventServiceImpl : EventService
    {
        private Context _context;

        public EventServiceImpl(Context context)
        {
            _context = context;
        }

        public Event save(Event e)
        {
            throw new System.NotImplementedException();
        }

        public Event findById(long id)
        {
            return _context.Events.First(p => p.Id == id);
        }

        public IEnumerable<Event> findAll()
        {
            throw new System.NotImplementedException();
        }

        public void deleteById(long id)
        {
            throw new System.NotImplementedException();
        }

        public Event update(Event e)
        {
            throw new System.NotImplementedException();
        }
    }
}