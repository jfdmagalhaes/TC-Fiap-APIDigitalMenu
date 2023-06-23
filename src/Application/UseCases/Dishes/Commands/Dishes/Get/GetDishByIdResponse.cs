using Domain.Entities;

namespace Application.UseCases.Dishes.Commands.Dishes.Get;
public class GetDishByIdResponse : DishEntity
{
    public string UriFile { get; set; }
}
