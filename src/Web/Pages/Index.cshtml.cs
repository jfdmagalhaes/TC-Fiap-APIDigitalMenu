using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Models;
using Web.ServiceClients;

namespace WebApplication1.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IDishesServiceClient _dishesServiceClient;

    public IndexModel(ILogger<IndexModel> logger, IDishesServiceClient dishesServiceClient)
    {
        _dishesServiceClient = dishesServiceClient ?? throw new ArgumentNullException(nameof(dishesServiceClient));
    }

    [BindProperty]
    public DishesViewModel Dishes { get; set; } = new();

    public async Task OnGet()
    {
        Dishes = await _dishesServiceClient.GetDishes();
    }
}