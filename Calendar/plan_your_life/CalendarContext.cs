using Calendar.plan_your_life.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calendar.plan_your_life
{
    public partial class Context : DbContext
    {
        public System.Data.Entity.DbSet<User> User { get; set; }
        public System.Data.Entity.DbSet<Event> Event { get; set; }
        public System.Data.Entity.DbSet<UserEvent> UserEvent { get; set; }

        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(
                    "Host=localhost;Port=5432;Database=plan_your_life;Username=postgres;Password=591563");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("character varying");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("character varying");

                entity.Property(e => e.StartAt)
                    .HasColumnName("StartAt")
                    .HasColumnType("date");

                entity.Property(e => e.EndAt)
                    .HasColumnName("EndAt")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Email)
                    .HasColumnName("Email")
                    .HasColumnType("character varying");

                entity.Property(e => e.UserName)
                    .HasColumnName("UserName")
                    .HasColumnType("character varying");

                entity.Property(e => e.Password)
                    .HasColumnName("Password")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<UserEvent>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("userevent_pk_2");

                entity.ToTable("UserEvent");

                entity.Property(e => e.Status).HasColumnName("Status");

                entity.Property(e => e.UserId).HasColumnName("UserId");

                entity.Property(e => e.EventId).HasColumnName("EventId");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.UserEvents)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("UserEvent_EventId_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserEvents)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("UserEvent_UserId_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}