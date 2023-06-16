namespace Web.Models;

public class Dish
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Value { get; set; }
    public IFormFile FileStream { get; set; }
}
