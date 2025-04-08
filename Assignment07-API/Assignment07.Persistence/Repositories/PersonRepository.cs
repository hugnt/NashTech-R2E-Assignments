using Assignment07.Domain.Entities;
using Assignment07.Domain.Enums;
using Assignment07.Domain.Primitives;
using Assignment07.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment07.Persistence.Repositories;

public class PersonRepository : Repository<Person>,IPersonRepository
{
	public PersonRepository(AppDbContext context) : base(context)
	{
		
	}

	public Person? GetById(Guid id)
	{
		return _context.Set<Person>().FirstOrDefault(x => x.Id == x.Id);
	}
}
