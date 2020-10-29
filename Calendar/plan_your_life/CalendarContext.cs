using Calendar.plan_your_life.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calendar.plan_your_life
{
    public class Context : DbContext
    {
        public System.Data.Entity.DbSet<User> Users { get; set; }
        public System.Data.Entity.DbSet<Event> Events { get; set; }
        public System.Data.Entity.DbSet<UserEvent> UserEvents { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=plan_your_life;Username=postgres;Password=591563");
        }
    }
}