using Calendar.plan_your_life.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.plan_your_life.Services.impl
{
    class UserEventServiceImpl : UserEventService
    {
        private Context _context;
        public UserEventServiceImpl(Context context)
        {
            _context = context;
        }
   
    }
}
