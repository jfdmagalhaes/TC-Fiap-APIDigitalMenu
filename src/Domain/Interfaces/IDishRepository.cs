using Domain.Entities;

namespace Domain.Interfaces;
public interface IDishRepository : IRepository<DishEntity>
{
    int AddDish(DishEntity dishRegister);
}
