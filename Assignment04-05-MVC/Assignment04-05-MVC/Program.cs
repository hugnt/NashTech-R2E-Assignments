using Assignment04_05_MVC.Middlewares;
using Assignment04_05_MVC.Models;
using Assignment04_05_MVC.Repositories;
using Assignment04_05_MVC.Services;
using Assignment04_05_MVC.Validators;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using FluentValidation;

namespace Assignment04_05_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
			//Exception handlers
			builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
			builder.Services.AddProblemDetails();

			// Add services to the container.
			builder.Services.AddControllersWithViews();


            //Add DI
            builder.Services.AddSingleton<IPersonRepository, PersonRepository>();
			builder.Services.AddSingleton<IPersonService, PersonService>();

			//Validator
			builder.Services.AddSingleton<IValidator<Person>, PersonValidator>();

			var app = builder.Build();
			app.UseExceptionHandler();
			app.UseMiddleware<ResultHandlingMiddleware>();

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
	            name: "nashtech",
	            pattern: "NashTech/{controller=Rookies}/{action=Index}/{id?}");


			app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Rookies}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
