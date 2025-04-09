using Assignment089.Domain.Entities;
using Assignment089.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Persistence.Repositories;

public class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
	public DepartmentRepository(AppDbContext context) : base(context)
	{
	}
}
