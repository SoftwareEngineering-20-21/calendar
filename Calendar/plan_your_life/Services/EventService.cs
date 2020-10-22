﻿using System.Collections.Generic;
 using Calendar.plan_your_life.Entities;


 namespace  Calendar.plan_your_life.Services
{
    public interface EventService
    {
        Event save(Event e);

        Event findById(long id);

        IEnumerable<Event> findAll();

        void deleteById(long id);

        Event update(Event e);
    }
}