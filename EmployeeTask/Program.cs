using AutoMapper;
using Data;
using EmployeeTask.Models;
using MegaGraphics.Services.Mapping;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Mapping;
using System.Reflection;

namespace EmployeeTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder.Services, builder.Configuration);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            
            app.Run();

        }
        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                 options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            services.AddMvc();
            services.AddRazorPages();

            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<IDepartmentService, DepartmentService>();


        }

    }
}