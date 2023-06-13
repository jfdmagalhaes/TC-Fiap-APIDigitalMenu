using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.ServiceClients;
public interface IDishesServiceClient
{
    Task<string> DishRegister(DishRegister dishRegister);
}