using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.ServiceClients;

public class DishesServiceClient : IDishesServiceClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DishesServiceClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    //TODO ajustar tipo para preço
    public async Task<IActionResult> DishRegister(DishRegister dishRegister)
    {
        var httpClient = _httpClientFactory.CreateClient("DishesServiceClient");
        HttpResponseMessage response = await httpClient.PostAsJsonAsync<DishRegister>("/DishRegister/register", dishRegister);

        if (response.IsSuccessStatusCode)
            return null;

        return null;
    }
}