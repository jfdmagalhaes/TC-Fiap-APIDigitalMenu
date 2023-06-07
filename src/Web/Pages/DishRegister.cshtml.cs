using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
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

        public async Task<IActionResult> OnPostAsync()
        {
            var dishRegisterData = new DishRegister() 
            { 
                Description = DishRegister.Description, 
                Name = DishRegister.Name, 
                Value = DishRegister.Value ,
                FileStream = DishRegister.FileStream               
            };

            var registerSucessfully = await _dishesServiceClient.DishRegister(dishRegisterData);

            var message = string.Empty;

            if (registerSucessfully != null) 
            {
                message  = "O prato foi cadastrado com sucesso!";
            }
            else
            {
                message = "Ocorreu um erro no cadastro do seu prato!";
            }
            
            TempData["Message"] = message;

            return RedirectToAction("DishRegister");
        }
    }
}
