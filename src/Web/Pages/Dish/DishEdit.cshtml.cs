using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Models;
using Web.ServiceClients;

namespace Web.Pages.Dish
{
    public class DishEditModel : PageModel
    {
        private readonly IDishesServiceClient _dishesServiceClient;

        public DishEditModel(IDishesServiceClient dishesServiceClient)
        {
            _dishesServiceClient = dishesServiceClient ?? throw new ArgumentNullException(nameof(dishesServiceClient));
        }

        [BindProperty]
        public Models.DishEditViewModel DishEdit { get; set; }
        
        public async Task<IActionResult> OnGet(int id)
        {
            DishEdit = await _dishesServiceClient.GetDishById(id);

            var message = string.Empty;
            if (DishEdit == null) message = "Ocorreu um erro ao buscar o prato selecionado!";

            TempData["Message"] = message;

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {

            var dishEditData = new Models.DishEditViewModel()
            {
                Description = DishEdit.Description,
                Name = DishEdit.Name,
                Price = DishEdit.Price,
                FileForm = DishEdit.FileForm,
                Id = DishEdit.Id
            };

            await _dishesServiceClient.DishEdit(dishEditData);
            return RedirectToPage("/Dish/DishList");
        }
    }
}
