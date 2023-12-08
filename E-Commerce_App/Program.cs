using E_Commerce_App.Data;
using E_Commerce_App.Models;
using E_Commerce_App.Repository;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(
                conf => conf.UseSqlServer(builder.Configuration.GetConnectionString("constr")));
            builder.Services.AddScoped<IActorRepository, ActorRepository>();
            builder.Services.AddScoped<IProducerRepository, ProducerRepository>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Movies}/{action=Index}/{id?}");

            AppDbIntializer.Seed(app);

            app.Run();
        }
    }
}