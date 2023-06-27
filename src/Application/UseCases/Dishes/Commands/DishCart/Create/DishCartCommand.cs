using MediatR;

namespace Application.UseCases.Dishes.Commands.DishCart.Create;
public class DishCartCommand : IRequest<DishCartResponse>
{
    public int DishId { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; } = 1;
}