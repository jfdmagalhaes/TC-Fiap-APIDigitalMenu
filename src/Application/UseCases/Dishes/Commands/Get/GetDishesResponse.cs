using Domain.Entities;

namespace Application.UseCases.Dishes.Commands.Get;
public class GetDishesResponse
{
    public List<DishEntity> Dishes { get; set; }
}
