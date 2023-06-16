using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.ServiceClients;
public interface IDishesServiceClient
{
    Task<string> DishRegister(Dish dishRegister);
    Task<List<Dish>> GetDishes();
}