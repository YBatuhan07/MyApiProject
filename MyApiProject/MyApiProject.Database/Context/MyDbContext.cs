using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyApiProject.Database.Context
{
    public class MyDbContext : IdentityDbContext<IdentityUser,IdentityRole,string>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);
            modelBuilder.Seed();
        }
    }
}
