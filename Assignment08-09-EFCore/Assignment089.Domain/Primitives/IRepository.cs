using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Domain.Primitives;

public interface IRepository<T> 
{
	public Task<IEnumerable<T?>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken token = default, params Expression<Func<T, object>>[] navigationProperties);
	public Task<IEnumerable<TDto>> SelectAsync<TDto>(Expression<Func<T, TDto>> selectQuery, Expression<Func<T, bool>>? predicate = null, CancellationToken token = default, params Expression<Func<T, object>>[] navigationProperties);
	public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken token = default, params Expression<Func<T, object>>[] navigationProperties);
	public Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken token = default, params Expression<Func<T, object>>[] navigationProperties);
	public Task<IEnumerable<TDto>> JoinAsync<TInner, TKey, TDto>(Expression<Func<T, TKey>> outerKeySelector,Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<T, TInner, TDto>> resultSelector, Expression<Func<T, bool>>? outerPredicate = null, Expression<Func<TInner, bool>>? innerPredicate = null, CancellationToken token = default) where TInner : Entity;
	public Task<IEnumerable<TDto>> ExecuteRawQueryAsync<TDto>(string rawSql, Expression<Func<T, TDto>> mapper, CancellationToken token = default, params object[] parameters);
	public Task ExecuteDeleteAsync(Expression<Func<T, bool>>? predicate = null);
	public Task AddRangeAsync(List<T> listEntity);
	public void Add(T entity);
	public void Update(T entity);
	public void Delete(T entity);
	public Task SaveChangesAsync(CancellationToken cancellationToken = default);

	public Task BeginTransactionAsync();
	public Task CommitAsync();
	public Task RollbackAsync();

}
