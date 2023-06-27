using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Models;
using Web.ServiceClients;

namespace Web.Pages.Dish
{
    public class DishCartModel : PageModel
    {
        private readonly IDishesServiceClient _dishesServiceClient;

        public DishCartModel(IDishesServiceClient dishesServiceClient)
        {
            _dishesServiceClient = dishesServiceClient ?? throw new ArgumentNullException(nameof(dishesServiceClient));
        }

        public DishCartViewModel DishCartViewModel { get; set; } = new();

        public async Task OnGet()
        {
            DishCartViewModel = await _dishesServiceClient.GetAllDishesCart();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var dish = await _dishesServiceClient.GetDishById(id);

            var ensureAddCart = await _dishesServiceClient.AddCartAsync(dish);
            if (ensureAddCart)
            {
                DishCartViewModel.Id = id;
                DishCartViewModel.DishItems.Add(new DishCarterItemViewModel 
                { 
                    Name = dish.Name,
                    Price = (decimal)dish.Price,
                    Id = dish.Id,
                    UriFile = dish.UriFile
                });
            }
            
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            await _dishesServiceClient.DeleteAllDishesCart();
            return RedirectToPage();
        }
    }
}