using Assignment.Data.Contexts;
using Assignment.Repository.Interfaces;
using Assignment.Repository.Repositories;
using Assignment.Service.Interfaces.Department;
using Assignment.Service.Interfaces.Employee;
using Assignment.Service.Mapping;
using Assignment.Service.Services;
using Microsoft.EntityFrameworkCore;

namespace Assaignment03.MVC.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AssignmentDBContext>(Options => 
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            
            //builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            builder.Services.AddAutoMapper(x => x.AddProfile(new EmployeeProfile()));
            builder.Services.AddAutoMapper(x => x.AddProfile(new DepartmentProfile()));




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
    }
}
