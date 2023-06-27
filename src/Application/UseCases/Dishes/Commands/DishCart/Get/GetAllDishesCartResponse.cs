namespace Application.UseCases.Dishes.Commands.DishCart.Get;
public class GetAllDishesCartResponse
{
    public int Id { get; set; }
    public List<DishCartItems> DishItems { get; set; } = new List<DishCartItems>();
}

public class DishCartItems
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string UriFile { get; set; }
}