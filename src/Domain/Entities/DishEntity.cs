using Domain.Interfaces;

namespace Domain.Entities;
public class DishEntity : IAggregateRoot
{
    public int Id { get; init; } 
    public string Name { get; init; }
    public string Description { get; init; }
    public int Value { get; init; } //TODO corrigir tipo
}