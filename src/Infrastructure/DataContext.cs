using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DataContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Interactions>().HasNoKey();
            builder.Entity<Photos>().HasNoKey();
            builder.Entity<Users>().HasNoKey();
            base.OnModelCreating(builder);
        }

      
        public DbSet<Certificates> Certificates { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Interactions> Interactions { get; set; }
        public DbSet<Photos> Photos { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
