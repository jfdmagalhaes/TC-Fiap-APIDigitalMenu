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

        MultipartFormDataContent formData = new();

        formData.Add(new StringContent(dishRegister.Name), "Name");
        formData.Add(new StringContent(dishRegister.Description), "Description");
        formData.Add(new StringContent(dishRegister.Value.ToString()), "Value");

        var file = dishRegister.FileStream;
        if (file != null)
        {
            var fileStreamContent = new StreamContent(file.OpenReadStream());
            formData.Add(fileStreamContent, "FileStream", file.FileName);
        }

        HttpResponseMessage response = await httpClient.PostAsync("/DishRegister/register", formData);

        if (response.IsSuccessStatusCode)
            return null;

        return null;
    }
}