using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Models;
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
        public DishesViewModel Dishes { get; set; } = new();

        public async Task OnGetAsync()
        {
            Dishes = await _dishesServiceClient.GetAllDishes();
        }

        public async Task<IActionResult> OnGetDelete(int id)
        {
            await _dishesServiceClient.DishDelete(id);
            return RedirectToAction("DishList");
        }
    }
}
