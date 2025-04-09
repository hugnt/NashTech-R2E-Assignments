using Assignment089.Domain.Primitives;
using Assignment089.Domain.Repositories;
using Assignment089.Persistence;
using Assignment089.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ServiceExtension
{
	public static IServiceCollection AddDIRepositories(this IServiceCollection services, IConfiguration configuration)
	{
		//db
		string connectionString = configuration.GetConnectionString("Database")!;

		services.AddDbContextPool<AppDbContext>(options =>
		{
			options.UseSqlServer(connectionString);
		},poolSize:128);

		//unit of work
		services.AddScoped<IUnitOfWork, UnitOfWork>();
		
		//Repositories
		services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
		services.AddScoped<IDepartmentRepository, DepartmentRepository>();

		return services;
	}
}