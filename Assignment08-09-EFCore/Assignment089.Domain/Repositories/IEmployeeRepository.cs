using Assignment089.Domain.Entities;
using Assignment089.Domain.Models;
using Assignment089.Domain.Primitives;
using System.Linq.Expressions;

namespace Assignment089.Domain.Repositories;

public interface IEmployeeRepository : IRepository<Employee>
{
	public Task<IEnumerable<TDto>> GetAllEmployeesWithProjects<TDto>(Expression<Func<IGrouping<EmployeeProjectKey, EmployeeProjectElement>, TDto>> resultSelector, CancellationToken cancellationToken = default);
	public Task<IEnumerable<EmployeeDepartmentQueryResult>> GetAllEmployeeWithDepartmentRawQuery();
	public Task<IEnumerable<EmployeeProjectQueryResult>> GetAllEmployeesWithProjectsRawQuery();
	public Task<IEnumerable<EmployeeSalaryQueryResult>> FilterEmployeeRawQuery(decimal? minAmount, DateTime? minJoinedDate);
}
