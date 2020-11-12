using System.Collections.Generic;
using System.Linq;
using Calendar.plan_your_life.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calendar.plan_your_life.Services.impl
{
    public class UserServiceImpl:UserService
    
    {
        private Context _context;

        public UserServiceImpl()
        {
            _context = new Context();
        }
        public User Save(User user)
        {
            User userToSave = _context.User.Add(user);
            _context.SaveChanges();
            return userToSave;
        }

        public User FindById(long id)
        {
            return _context.User.First(p => p.Id == id);
        }

        public IEnumerable<User> FindAll()
        {
            return _context.User.ToList();
        }

        public void DeleteById(long id)
        {
            _context.User.Remove(FindById(id));
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