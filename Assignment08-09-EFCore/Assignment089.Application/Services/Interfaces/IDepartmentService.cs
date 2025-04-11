using Assignment089.Application.Models.Requests;
using Assignment089.Application.Models.Responses;
using Assignment089.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Application.Services.Interfaces;

public interface IDepartmentService
{
	public Task<Result<List<DepartmentResponse>>> GetAll();
	public Task<Result> GetById(Guid id);
	public Task<Result> Add(DepartmentRequest newDepartment);
	public Task<Result> Update(Guid id, DepartmentRequest updatedDepartment);
	public Task<Result> Delete(Guid id);
}
