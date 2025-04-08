using Assignment07.Domain.Entities;
using Assignment07.Domain.Primitives;
using Assignment07.Domain.Repositories;
using Assignment07.Persistence;
using Assignment07.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment07.Application;

public static class ServiceExtension
{
	public static IServiceCollection AddDIRepositories(this IServiceCollection services, IConfiguration configuration)
	{
		//db
		services.AddDbContext<AppDbContext>(options =>
		{
			options.UseInMemoryDatabase(databaseName:"Persondb");
		});

		//unit of work
		services.AddScoped<IUnitOfWork, UnitOfWork>();

		//Repositories
		services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
		services.AddScoped<IPersonRepository, PersonRepository>();

		return services;
	}
}
