using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyApiProject.ApplicationLayer;
using MyApiProject.ApplicationLayer.Auths;
using MyApiProject.ApplicationLayer.Personnels;
using MyApiProject.Database.Context;
using MyApiProject.Database.Repositories;
using MyApiProject.Database.UnitOfWork;
using MyApiProject.MiddleWare;
using Serilog;
using System.Security.Claims;
using System.Text;

namespace MyApiProject;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day).CreateLogger();

        // Add services to the container.
        builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<MyDbContext>()
            .AddDefaultTokenProviders();

        var jwtSettings = builder.Configuration.GetSection("Jwt");

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                ValidAudience = jwtSettings.GetSection("Audience").Value,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("Key").Value)),
                RoleClaimType = ClaimTypes.Role
            };
        });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
        });

        builder.Services.AddControllers();
        builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=MyApiProjectDb"));
        builder.Services.AddScoped<ICityService, CityService>();
        builder.Services.AddScoped<ICityRepository, CityRepository>();

        builder.Services.AddScoped<IDistrictService, DistrictService>();
        builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();

        builder.Services.AddScoped<IPersonnelService, PersonnelService>();
        builder.Services.AddScoped<IPersonelRepository, PersonelRepository>();

        builder.Services.AddScoped<IAuthService, AuthService>();

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(x =>
        {
            x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Example APIs", Version = "v1" });

            x.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "Jwt",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Description = "Jwt token gerekli: Bearer {token}"
            });
            x.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });

        });

        var app = builder.Build();

        using(var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            await ContextSeed.CreateIdmAdminUser(services);
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseMiddleware<ErrorHandling>();

        app.MapControllers();

        app.Run();
    }
}