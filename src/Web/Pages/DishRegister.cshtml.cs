using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Models;
using Web.ServiceClients;

namespace WebApp.Pages
{
    public class DishRegisterModel : PageModel
    {
        private readonly IDishesServiceClient _dishesServiceClient;

        public DishRegisterModel(IDishesServiceClient dishesServiceClient)
        {
            _dishesServiceClient = dishesServiceClient;
        }

        [BindProperty]
        public DishRegister DishRegister { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            _dishesServiceClient.DishRegister(DishRegister.Name, DishRegister.Description, DishRegister.Value);
            return RedirectToPage("/Index");

        }
    }
}
