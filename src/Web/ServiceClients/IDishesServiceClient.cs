using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.ServiceClients;
public interface IDishesServiceClient
{
    Task<IActionResult> DishRegister(DishRegister dishRegister);
}