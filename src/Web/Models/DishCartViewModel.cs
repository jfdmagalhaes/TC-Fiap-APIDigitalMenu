namespace Web.Models;

public class DishCartViewModel
{
    public int Id { get; set; }
    public List<DishCarterItemViewModel> DishItems { get; set; } = new List<DishCarterItemViewModel>();

    public decimal Total()
    {
        return Math.Round(DishItems.Sum(x => x.Price * x.Quantity), 2);
    }
}

public class DishCarterItemViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string UriFile { get; set; }
}