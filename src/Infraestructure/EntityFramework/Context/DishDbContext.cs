using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Infraestructure.EntityFramework.Context;
public class DishDbContext : DbContext, IDishDbContext, IUnitOfWork
{
    public IDbConnection Connection => base.Database.GetDbConnection();
    private IDbContextTransaction _currentTransaction;
    public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

    public DbSet<DishEntity> Dishes { get; set; }


    public DishDbContext(DbContextOptions<DishDbContext> options)
    : base(options)
    {
    }

    public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken) > 0;
    }
}
