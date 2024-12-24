using Microsoft.EntityFrameworkCore;
using MyApiProject.ApplicationLayer;
using MyApiProject.ApplicationLayer.Personnels;
using MyApiProject.Database.Context;
using MyApiProject.Database.Repositories;
using MyApiProject.Database.UnitOfWork;
using MyApiProject.MiddleWare;
using Serilog;

namespace MyApiProject;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("Logs/log.txt",rollingInterval:RollingInterval.Day).CreateLogger();

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=MyApiProjectDb"));
        builder.Services.AddScoped<ICityService, CityService>();
        builder.Services.AddScoped<ICityRepository, CityRepository>();

        builder.Services.AddScoped<IDistrictService, DistrictService>();
        builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();

        builder.Services.AddScoped<IPersonnelService, PersonnelService>();
        builder.Services.AddScoped<IPersonelRepository, PersonelRepository>();

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseMiddleware<ErrorHandling>();

        app.MapControllers();

        app.Run();
    }
}