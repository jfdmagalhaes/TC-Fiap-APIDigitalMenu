using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.ServiceClients;
public interface IDishesServiceClient
{
    Task<string> DishRegister(DishRegisterViewModel dishRegister);
    Task<DishesViewModel> GetAllDishes();
    Task<DishData> GetDishById(int id);
    Task<bool> DishEdit(DishEditViewModel dishEdit);
}