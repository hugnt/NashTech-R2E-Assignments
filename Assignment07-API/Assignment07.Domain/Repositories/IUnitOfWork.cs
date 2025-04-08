using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment07.Domain.Repositories;

public interface IUnitOfWork
{
	void SaveChanges();
}
