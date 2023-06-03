using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Web.ServiceClients;

public class DishesServiceClient : IDishesServiceClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DishesServiceClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    //TODO ajustar tipo para preço
    public async Task<IActionResult> DishRegister(string name, string description, int price)
    {
        var httpClient = _httpClientFactory.CreateClient("DishesServiceClient");
        HttpResponseMessage response = await httpClient.PostAsJsonAsync("/register", JsonConvert.SerializeObject(name));

        return null;
    }
}
