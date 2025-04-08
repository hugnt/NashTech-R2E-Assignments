
using Assignment07.API.Middlewares;
using Assignment07.Application;
using Assignment07.Domain.Entities;
using Assignment07.Domain.Enums;
using Assignment07.Persistence;
using Assignment07.Persistence.Data;

namespace Assignment07.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			//Exception handlers
			builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
			builder.Services.AddProblemDetails();

			// Add db & repositoriy settings to the container.
			builder.Services.AddDIRepositories(builder.Configuration);

			// Add services to the container.
			builder.Services.AddDIServices(builder.Configuration);

		
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();
			app.UseExceptionHandler();
			app.UseMiddleware<ResultHandlingMiddleware>();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			using(var scope = app.Services.CreateScope())
			{
				var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
				DataProvider.SeedData(context);
			}

			app.Run();
		}

	
	}


}
