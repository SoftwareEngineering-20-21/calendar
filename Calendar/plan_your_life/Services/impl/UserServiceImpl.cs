using System.Collections.Generic;
using System.Linq;
using Calendar.plan_your_life.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calendar.plan_your_life.Services.impl
{
    public class UserServiceImpl:UserService
    
    {
        private Context _context;

        public UserServiceImpl(Context context)
        {
            _context = context;
        }
        public User Save(User user)
        {
            var entry = _context.Users.Add(user);
            _context.SaveChanges();

            return entry.Entity;
        }

        public User FindById(long id)
        {
            return _context.Users.First(p => p.Id == id);
        }

        public IEnumerable<User> FindAll()
        {
            return _context.Users.ToList();
        }

        public void DeleteById(long id)
        {
            _context.Users.Remove(FindById(id));
            _context.SaveChanges();
        }

        public User Update(User user)
        {
            User userToUpdate = FindById(user.Id);
            userToUpdate.Password = user.Password;
            
            _context.Entry(userToUpdate).State = EntityState.Modified;
            _context.SaveChanges();
            return userToUpdate;
        }
    }
}