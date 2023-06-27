using Domain.Interfaces;

namespace Domain.Entities;
public class DishCartEntity : IAggregateRoot
{
    public int CartId { get; init; }
    public int DishId { get; init; }
    public int Quantity { get; init; }
    public double UnitPrice { get; init; }
    public DishEntity DishEntity { get; init; }
}