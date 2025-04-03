using Microsoft.Extensions.DependencyInjection;
using TodoList.Application.Abstractions;
using TodoList.Persistence.Repositories;
using TodoList.Persistence.Services;

namespace TodoList.Persistence;

public static class DependencyInjection {
	public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
	{
		return services.AddSingleton<ITodoRepository, TodoRepository>()
						.AddSingleton<ITodoService, TodoService>();
	}
}
