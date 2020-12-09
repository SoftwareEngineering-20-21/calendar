using System.Collections.Generic;
using Calendar.plan_your_life.Entities;


namespace Calendar.plan_your_life.Services
{
    public interface EventService
    {
        Event Save(Event e);

        void Save(Event e,long userId);

        Event FindById(long id);

        IEnumerable<Event> FindAll();

        void DeleteById(long id);

        Event Update(Event e);

        IEnumerable<Event> FindAllByUserId(long id);
    }
}