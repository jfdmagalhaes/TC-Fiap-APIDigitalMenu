using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.UseCases.Dishes.Commands.Get;
public class GetDishesResponse
{
    public List<DishResponse> Dishes { get; set; } = new();
}

public class DishResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string UriFile { get; set; }
}