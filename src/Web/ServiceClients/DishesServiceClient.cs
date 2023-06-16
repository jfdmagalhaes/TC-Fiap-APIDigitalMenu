using Domain.Entities;
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
    public async Task<string> DishRegister(Dish dishRegister)
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

        var response = await httpClient.PostAsync("/DishRegister/register", formData);
        response.EnsureSuccessStatusCode();

        var contentResponse = response.Content.ReadAsStringAsync().Result;

        if (response.IsSuccessStatusCode)
            return contentResponse;

        return null;
    }


    public async Task<List<Dish>> GetDishes()
    {
        var httpClient = _httpClientFactory.CreateClient("DishesServiceClient");

        var response = await httpClient.GetAsync("/DishRegister/getAllDishes");
        response.EnsureSuccessStatusCode();

        var contentResponse = response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var stringData = await response.Content.ReadAsStringAsync();

            var listinha = JsonConvert.DeserializeObject<List<DishEntity>>(stringData);
        }

        //if (response.IsSuccessStatusCode)
        //    return contentResponse;

        return new List<Dish>();
    }
}