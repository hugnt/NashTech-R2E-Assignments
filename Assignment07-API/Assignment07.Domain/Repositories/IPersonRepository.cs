using Assignment07.Domain.Entities;
using Assignment07.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment07.Domain.Repositories;

public interface IPersonRepository : IRepository<Person>
{
	public Person? GetById(Guid id);
}
