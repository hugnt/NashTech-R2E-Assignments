using Assignment089.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Persistence;

public sealed class UnitOfWork : IUnitOfWork
{
	private readonly AppDbContext _dbContext;

	public UnitOfWork(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}
	public Task SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		return _dbContext.SaveChangesAsync(cancellationToken);
	}
}
