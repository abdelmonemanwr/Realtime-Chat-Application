using Microsoft.EntityFrameworkCore;
using SignalrD1.Hubs;
using SignalrD1.Models;

namespace SignalrD1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSignalR();
            builder.Services.AddDbContext<ITIContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("iticon")));
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

            app.MapHub<ChatHub>("/chat");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=chat}/{action=Index}/{id?}");

            app.Run();
        }
    }
}