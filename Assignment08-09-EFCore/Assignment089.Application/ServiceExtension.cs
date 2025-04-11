using Assignment089.Application.Models.Requests;
using Assignment089.Application.Services;
using Assignment089.Application.Services.Interfaces;
using Assignment089.Application.Validators;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Application;

public static class ServiceExtension
{
	public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
	{
		//Validator
		services.AddSingleton<IValidator<DepartmentRequest>, DepartmentRequestValidator>();
		services.AddSingleton<IValidator<EmployeeRequest>, EmployeeRequestValidator>();
		services.AddSingleton<IValidator<SalaryRequest>, SalaryRequestValidator>();
		services.AddSingleton<IValidator<ProjectRequest>, ProjectRequestValidator>();

		//Services
		services.AddScoped<IDepartmentService, DepartmentService>();
		services.AddScoped<IEmployeeService, EmployeeService>();
		services.AddScoped<ISalaryService, SalaryService>();
		services.AddScoped<IProjectService, ProjectService>();
		services.AddScoped<IProjectEmployeeService, ProjectEmployeeService>();

		return services;
	}
}
