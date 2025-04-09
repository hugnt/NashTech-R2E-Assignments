using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Domain.Primitives;

public interface IRepository<T> where T : Entity
{
	public IQueryable<T> GetAll();
	public void Add(T entity);
	public void Update(T entity);
	public void Delete(T entity);
}
