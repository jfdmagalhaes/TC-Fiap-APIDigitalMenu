using Microsoft.AspNetCore.Mvc;

namespace Web.ServiceClients;
public interface IDishesServiceClient
{
    Task<IActionResult> DishRegister(string dishName, string dishDescription, int dishPrice);
}