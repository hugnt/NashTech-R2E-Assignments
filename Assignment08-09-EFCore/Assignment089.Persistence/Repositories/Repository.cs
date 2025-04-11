using Assignment089.Domain.Entities;
using Assignment089.Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
	protected readonly AppDbContext _context;
	protected IDbContextTransaction? _transaction;
	public Repository(AppDbContext context)
	{
		_context = context;
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

	public async Task ExecuteDeleteAsync(Expression<Func<T, bool>>? predicate = null)
	{
		if (predicate != null)
		{
			await _context.Set<T>().Where(predicate).ExecuteDeleteAsync();
		}
		else await _context.Set<T>().Where(predicate).ExecuteDeleteAsync();

	}

	public async Task AddRangeAsync(List<T> listEntity)
	{
		await _context.Set<T>().AddRangeAsync(listEntity);
	}


	public virtual async Task<IEnumerable<T?>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken token = default, params Expression<Func<T, object>>[] navigationProperties)
	{
		return await GetQuery(predicate, navigationProperties).ToListAsync(token);
	}

	public virtual async Task<IEnumerable<TDto>> SelectAsync<TDto>(Expression<Func<T, TDto>> selectQuery,
													   Expression<Func<T, bool>>? predicate = null,
													   CancellationToken token = default,
													   params Expression<Func<T, object>>[] navigationProperties)
	{
		return await GetQuery(predicate, navigationProperties)
			.Select(selectQuery)
			.ToListAsync(token);
	}

	public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken token = default, params Expression<Func<T, object>>[] navigationProperties)
	{
		return await GetQuery(predicate, navigationProperties).FirstOrDefaultAsync(token);
	}

	public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken token = default, params Expression<Func<T, object>>[] navigationProperties)
	{
		return await GetQuery(predicate, navigationProperties).AnyAsync(token);
	}

	public async Task<IEnumerable<TDto>> JoinAsync<TInner, TKey, TDto>(
		Expression<Func<T, TKey>> outerKeySelector,
		Expression<Func<TInner, TKey>> innerKeySelector,
		Expression<Func<T, TInner, TDto>> resultSelector,
		Expression<Func<T, bool>>? outerPredicate = null,
		Expression<Func<TInner, bool>>? innerPredicate = null,
		CancellationToken token = default) where TInner : Entity
	{
		var outerQuery = _context.Set<T>().AsNoTracking();
		var innerQuery = _context.Set<TInner>().AsNoTracking();
		if (outerPredicate != null) outerQuery = outerQuery.Where(outerPredicate); 
		if (innerPredicate != null) innerQuery = innerQuery.Where(innerPredicate);
		
		var joinedQuery = outerQuery.Join(
			innerQuery,
			outerKeySelector,
			innerKeySelector,
			resultSelector);
	
		return await joinedQuery.ToListAsync(token);
	}

	public virtual async Task<IEnumerable<TDto>> ExecuteRawQueryAsync<TDto>(string rawSql, Expression<Func<T, TDto>> mapper, CancellationToken token = default, params object[] parameters)
	{
		var query = _context.Set<T>().FromSqlRaw(rawSql, parameters);
		return await query.AsNoTracking().Select(mapper).ToListAsync(token);
	}

	public Task SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		return _context.SaveChangesAsync(cancellationToken);
	}

	protected IQueryable<T> GetQuery(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] navigationProperties)
	{
		IQueryable<T> dbQuery = _context.Set<T>().AsNoTracking();
		if (predicate != null)
		{
			dbQuery = dbQuery.Where(predicate);
		}
		return navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include(navigationProperty));
	}

	public async Task BeginTransactionAsync()
	{
		_transaction = await _context.Database.BeginTransactionAsync();
	}

	public async Task CommitAsync()
	{
		if (_transaction != null)
		{
			await _transaction.CommitAsync();
			await _transaction.DisposeAsync();
			_transaction = null;
		}
		
	}

	public async Task RollbackAsync()
	{
		if (_transaction != null)
		{
			await _transaction.RollbackAsync();
			await _transaction.DisposeAsync();
			_transaction = null;
		}
		
	}



}
