using Calendar.plan_your_life.Entities;
using Microsoft.EntityFrameworkCore;


namespace Calendar.plan_your_life
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=calendar;Username=postgres;Password=13052001");
        }
    }
}