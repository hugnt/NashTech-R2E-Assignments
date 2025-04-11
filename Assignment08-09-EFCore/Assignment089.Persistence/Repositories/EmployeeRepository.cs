using Assignment089.Domain.Entities;
using Assignment089.Domain.Models;
using Assignment089.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq.Expressions;

namespace Assignment089.Persistence.Repositories;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
	public EmployeeRepository(AppDbContext context) : base(context)
	{
	}

	public async Task<IEnumerable<TDto>> GetAllEmployeesWithProjects<TDto>(Expression<Func<IGrouping<EmployeeProjectKey, EmployeeProjectElement>, TDto>> resultSelector, CancellationToken cancellationToken = default)
	{
		var query = _context.Employees
								.GroupJoin(_context.ProjectEmployees,
										   employee => employee.Id,
										   projectEmployee => projectEmployee.EmployeeId,
										   (employee, lstProjectEmployee) => new
										   {
											   Employee = employee,
											   ListProjectEmployee = lstProjectEmployee
										   })
								.SelectMany(res => res.ListProjectEmployee.DefaultIfEmpty(),
										   (res, projectEmployee) => new
										   {
											   Employee = res.Employee,
											   ProjectEmployee = projectEmployee
										   })
								.GroupJoin(_context.Projects,
											res => res.ProjectEmployee != null ? res.ProjectEmployee.ProjectId : (Guid?)null,
											project => project.Id,
											(res, lstProject) => new
											{
												Employee = res.Employee,
												ProjectEmployee = res.ProjectEmployee,
												ListProject = lstProject
											})
								.SelectMany(res => res.ListProject.DefaultIfEmpty(),
										    (res, project) => new
										   {
											   EmployeeId = res.Employee.Id,
											   EmployeeName = res.Employee.Name,
											   JoinedDate = res.Employee.JoinedDate,
											   ProjectEmployee = res.ProjectEmployee,
											   Project = project
										   })
								.GroupBy(x => new EmployeeProjectKey{ Id = x.EmployeeId, Name =  x.EmployeeName, JoinedDate = x.JoinedDate },
										 x => new EmployeeProjectElement
										 {
											 Project = x.Project,
											 ProjectEmployee = x.ProjectEmployee
										 })
								.Select(resultSelector);

		var res = await query.ToListAsync();
		return res;
	}

	public async Task<IEnumerable<EmployeeDepartmentQueryResult>> GetAllEmployeeWithDepartmentRawQuery()
	{
		string query = @"
            SELECT e.Id, e.Name, e.JoinedDate, d.Name AS DepartmentName
            FROM Employee e
            INNER JOIN Department d ON e.DepartmentId = d.Id";
		var result = await _context.Set<EmployeeDepartmentQueryResult>()
				.FromSqlRaw(query)
				.ToListAsync();

		return result;
	}

	public async Task<IEnumerable<EmployeeProjectQueryResult>> GetAllEmployeesWithProjectsRawQuery()
	{
		string query = @"
            SELECT e.Id, e.Name, e.JoinedDate, p.Name AS ProjectName, pe.Enable AS Enable
			FROM Employee e
			LEFT JOIN ProjectEmployee pe ON e.Id = pe.EmployeeId
			LEFT JOIN Project p ON pe.ProjectId = p.Id";
		var result = await _context.Set<EmployeeProjectQueryResult>()
				.FromSqlRaw(query)
				.ToListAsync();

		return result;
	}

	public async Task<IEnumerable<EmployeeSalaryQueryResult>> FilterEmployeeRawQuery(decimal? minAmount, DateTime? minJoinedDate)
	{
		string baseQuery = @"
                SELECT e.Id, e.Name, e.JoinedDate, s.Amount AS Amount
                FROM Employee e
                LEFT JOIN Salary s ON e.Id = s.EmployeeId";

		var conditions = new List<string>();
		var parameters = new List<object>();

		if (minAmount.HasValue)
		{
			conditions.Add("s.Amount > {0}");
			parameters.Add(minAmount.Value);
		}

		if (minJoinedDate.HasValue)
		{
			conditions.Add("e.JoinedDate >= {1}");
			parameters.Add(minJoinedDate.Value);
		}

		// Combine query
		string query = baseQuery;
		if (conditions.Any())
		{
			query += " WHERE " + string.Join(" AND ", conditions);
		}
		var result = await _context.Set<EmployeeSalaryQueryResult>()
				.FromSqlRaw(query, parameters.ToArray())
				.ToListAsync();

		return result;
	}
}
