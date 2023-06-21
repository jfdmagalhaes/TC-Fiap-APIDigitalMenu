using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Models;
using Web.ServiceClients;

namespace Web.Pages
{
    public class PublicDigitalMenuModel : PageModel
    {
        private readonly IDishesServiceClient _dishesServiceClient;

        public PublicDigitalMenuModel(IDishesServiceClient dishesServiceClient)
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
}
