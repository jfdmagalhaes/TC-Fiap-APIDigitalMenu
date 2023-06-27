using Domain.Entities;

namespace Application.UseCases.Dishes.Commands.DishCart.Create;
public class DishCartResponse
{
    public int CartId { get; set; }
    public int DishId { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
}