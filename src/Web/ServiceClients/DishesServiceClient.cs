using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    public async Task<string> DishRegister(CreateDishViewModel dishRegister)
    {
        var httpClient = _httpClientFactory.CreateClient("DishesServiceClient");

        MultipartFormDataContent formData = new();

        formData.Add(new StringContent(dishRegister.Name), "Name");
        formData.Add(new StringContent(dishRegister.Description), "Description");
        formData.Add(new StringContent(dishRegister.Price.ToString()), "Price");

        var file = dishRegister.FileForm;
        if (file != null)
        {
            var fileFormContent = new StreamContent(file.OpenReadStream());
            formData.Add(fileFormContent, "FileForm", file.FileName);
        }

        var response = await httpClient.PostAsync("/DishRegister/register", formData);
        response.EnsureSuccessStatusCode();

        var contentResponse = response.Content.ReadAsStringAsync().Result;

        if (response.IsSuccessStatusCode)
            return contentResponse;

        return null;
    }


    public async Task<DishesViewModel> GetDishes()
    {
        var httpClient = _httpClientFactory.CreateClient("DishesServiceClient");

        var response = await httpClient.GetAsync("/DishRegister/getAllDishes");
        response.EnsureSuccessStatusCode();

        var allDishes = new DishesViewModel();
        if (response.IsSuccessStatusCode)
        {
            var stringData = await response.Content.ReadAsStringAsync();
            allDishes = JsonConvert.DeserializeObject<DishesViewModel>(stringData);
        }

        return allDishes;
    }
}