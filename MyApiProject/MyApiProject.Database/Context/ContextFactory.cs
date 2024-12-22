using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyApiProject.Database.Context;

public sealed class ContextFactory : IDesignTimeDbContextFactory<MyDbContext>
{
    public MyDbContext CreateDbContext(string[] args)
    {
        const string connectionString = "server=(localdb)\\MSSQLLocalDB;database=MyApiProjectDb";
        return new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseSqlServer(connectionString).Options);
    }
}
