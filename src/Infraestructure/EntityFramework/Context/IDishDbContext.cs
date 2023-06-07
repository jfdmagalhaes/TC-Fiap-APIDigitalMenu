using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Infraestructure.EntityFramework.Context;
public interface IDishDbContext : IUnitOfWork
{
    IDbConnection Connection { get; }
    DbSet<DishEntity> Dishes { get; }

    Task<bool> CommitAsync(CancellationToken cancellationToken = default);
    IDbContextTransaction GetCurrentTransaction();
}