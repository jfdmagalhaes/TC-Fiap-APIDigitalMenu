using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.ServiceClients;

namespace Web.Pages.Dish
{
    public class DishListModel : PageModel
    {
        private readonly IDishesServiceClient _dishesServiceClient;

        public DishListModel(IDishesServiceClient dishesServiceClient)
        {
            _dishesServiceClient = dishesServiceClient ?? throw new ArgumentNullException(nameof(dishesServiceClient));
        }

        [BindProperty]
        public List<Models.Dish> Dishes { get; set; } = new List<Models.Dish>();

        public async Task OnGet()
        {
            Dishes = await _dishesServiceClient.GetDishes();
        }
    }
}
