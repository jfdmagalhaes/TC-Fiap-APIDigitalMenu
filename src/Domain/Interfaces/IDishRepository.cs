using Domain.Entities;

namespace Domain.Interfaces;
public interface IDishRepository : IRepository<DishEntity>
{
    Task AddDishAsync(DishEntity dishRegister);
    Task<List<DishEntity>> GetAllDishesAsync();
}
