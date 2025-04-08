using Assignment07.Application.Models.Requests;
using Assignment07.Application.Models.Responses;
using Assignment07.Domain.Entities;
using Assignment07.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment07.Application.Services;

public interface IPersonService
{
	public Result Add(PersonRequest newPerson);
	public Result Update(Guid id,PersonRequest updatedPerson);
	public Result Delete(Guid id);
	public Result<List<PersonResponse>> Filter(PersonFilterRequest filterModel);

}
