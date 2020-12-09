
using System.Collections.Generic;
using Calendar.plan_your_life.Entities;

namespace Calendar.plan_your_life.Services
{
    public interface UserService
    {
        User Save(User user);

        User FindById(long id);

        User FindByEmail(string email);

        IEnumerable<User> FindAll();

        void DeleteById(long id);

        User Update(User user);
    }
}