using Assignment07.Application.Models.Requests;
using Assignment07.Application.Services;
using Assignment07.Application.Validators;
using Assignment07.Persistence;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment07.Application;

public static class ServiceExtension
{
	public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
	{
		//Validator
		services.AddSingleton<IValidator<PersonRequest>, PersonRequestValidator>();

		//Services
		services.AddScoped<IPersonService, PersonService>();

		return services;
	}
}
