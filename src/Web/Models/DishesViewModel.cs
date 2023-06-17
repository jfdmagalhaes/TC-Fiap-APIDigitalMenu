namespace Web.Models;

public class DishesViewModel
{
    public List<DishData> Dishes { get; set; } = new();
}

public class DishData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string UriFile { get; set; }
}