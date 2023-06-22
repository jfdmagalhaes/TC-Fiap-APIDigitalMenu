namespace Web.Models;

public class DishRegisterViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public IFormFile FileForm { get; set; }
}