using Assignment089.Application.Models.Requests;
using Assignment089.Application.Models.Responses;
using Assignment089.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Application.Services.Interfaces;

public interface ISalaryService
{
	public Task<Result<List<SalaryResponse>>> GetAll();
	public Task<Result> GetById(Guid id);
	public Task<Result> Add(SalaryRequest newSalary);
	public Task<Result> Update(Guid id, SalaryRequest updatedSalary);
	public Task<Result> Delete(Guid id);
}
