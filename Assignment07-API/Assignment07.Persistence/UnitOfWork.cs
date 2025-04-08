using Assignment07.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment07.Persistence
{
	public sealed class UnitOfWork:IUnitOfWork
	{
		private readonly AppDbContext _context;

		public UnitOfWork(AppDbContext context)
		{
			_context = context;
		}

		public void SaveChanges()
		{

			_context.SaveChanges();
		}
	}
}
