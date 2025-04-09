using Assignment089.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : Entity
{
	protected readonly AppDbContext _context;
	public Repository(AppDbContext context)
	{
		_context = context;
	}
	public IQueryable<T> GetAll()
	{
		return _context.Set<T>();
	}

	public void Add(T entity)
	{
		_context.Set<T>().Add(entity);
	}
	public void Update(T entity)
	{
		_context.Set<T>().Update(entity);
	}

	public void Delete(T entity)
	{
		_context.Set<T>().Remove(entity);
	}


}
