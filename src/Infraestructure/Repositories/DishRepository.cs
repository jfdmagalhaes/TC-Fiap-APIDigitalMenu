using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infraestructure.Repositories;

public class DishRepository : IDishRepository
{
    private readonly IDishDbContext _context;
    private readonly IConfiguration _configuration;
    public IUnitOfWork UnitOfWork => _context;

    public DishRepository(IDishDbContext context, IConfiguration configuration)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    //TODO acho que nem vou usar, pode ser removido
    public string GetConnection()
    {
        return _configuration.GetSection("ConnectionStrings").GetSection("AppConnection").Value!;
    }

    public async Task AddDishAsync(DishEntity dishRegister)
    {
       await _context.Dishes.AddAsync(dishRegister);
    }

    public async Task<List<DishEntity>> GetAllDishesAsync()
    {
        return await _context.Dishes.ToListAsync();
    }

    public async Task<DishEntity> GetDishByIdAsync(int id)
    {
        return await _context.Dishes.Where(x => x.Id == id).AsNoTracking().FirstAsync();
    }

    public void UpdateDish(DishEntity dishRegister)
    {
        _context.Dishes.Update(dishRegister);
    }

    public void DeleteDish(DishEntity dish)
    {
        _context.Dishes.Remove(dish);
    }

    private bool disposedValue = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);

    }
}