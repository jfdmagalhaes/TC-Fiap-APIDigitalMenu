using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            var dish = await _dishesServiceClient.GetDishById(id);

            DishEdit.Description = dish.Description;
            DishEdit.Price = dish.Price;
            DishEdit.Name = dish.Name;

            return null;
        }


        public async Task<IActionResult> OnPostAsync()
        {
            var dishEditModel = new Models.DishEditViewModel()
            {
                Id = DishEdit.Id,
                Description = DishEdit.Description,
                Name = DishEdit.Name,
                Price = DishEdit.Price,
                FileForm = DishEdit.FileForm
            };

            var success = await _dishesServiceClient.DishEdit(dishEditModel);

            var message = string.Empty;
            if (success)
            {
                message = $"Alteração realizada com sucesso ";
            }
            else
            {
                message = "Ocorreu um erro na alteração do seu prato!";
            }

            TempData["Message"] = message;
            return RedirectToAction("DishList");
        }
    }
}
