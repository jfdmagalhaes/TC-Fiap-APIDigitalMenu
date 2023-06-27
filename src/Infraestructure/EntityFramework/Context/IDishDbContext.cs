using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infraestructure.EntityFramework.Context;
public interface IDishDbContext : IUnitOfWork
{
    IDbConnection Connection { get; }
    DbSet<DishEntity> Dishes { get; }
    DbSet<DishCartEntity> DishesCart { get; }
}