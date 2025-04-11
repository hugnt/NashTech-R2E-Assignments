using Assignment089.Domain.Entities;
using Assignment089.Domain.Models;
using Assignment089.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Metadata;

namespace Assignment089.Persistence;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{

	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
	  

	public DbSet<Department> Departments { get; set; }
	public DbSet<Employee> Employees { get; set; }
	public DbSet<Project> Projects { get; set; }
	public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
	public DbSet<Salary> Salaries { get; set; }

	public DbSet<EmployeeDepartmentQueryResult> EmployeeDepartmentQueryResults { get; set; }
	public DbSet<EmployeeProjectQueryResult> EmployeeProjectQueryResults { get; set; }
	public DbSet<EmployeeSalaryQueryResult> EmployeeSalaryQueryResults { get; set; }
}
