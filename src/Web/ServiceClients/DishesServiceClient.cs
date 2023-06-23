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

    public async Task<string> DishRegister(DishRegisterViewModel dishRegister)
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

        var response = await httpClient.PostAsync("/Dish/register", formData);
        response.EnsureSuccessStatusCode();

        var contentResponse = response.Content.ReadAsStringAsync().Result;

        if (response.IsSuccessStatusCode)
            return contentResponse;

        return null;
    }


    public async Task<DishesViewModel> GetAllDishes()
    {
        var httpClient = _httpClientFactory.CreateClient("DishesServiceClient");

        var response = await httpClient.GetAsync("/Dish/getAllDishes");
        response.EnsureSuccessStatusCode();

        var allDishes = new DishesViewModel();
        if (response.IsSuccessStatusCode)
        {
            var stringData = await response.Content.ReadAsStringAsync();
            allDishes = JsonConvert.DeserializeObject<DishesViewModel>(stringData);
        }

        return allDishes;
    }

    public async Task<DishData> GetDishById(int id)
    {
        var httpClient = _httpClientFactory.CreateClient("DishesServiceClient");

        var response = await httpClient.GetAsync($"/Dish/getDishById?Id={id}");
        response.EnsureSuccessStatusCode();

        var dishFounded = new DishData();
        if (response.IsSuccessStatusCode)
        {
            var stringData = await response.Content.ReadAsStringAsync();
            dishFounded = JsonConvert.DeserializeObject<DishData>(stringData);
        }

        return dishFounded;
    }

    public async Task<bool> DishEdit(DishEditViewModel dishEdit)
    {
        var httpClient = _httpClientFactory.CreateClient("DishesServiceClient");

        MultipartFormDataContent formData = new();

        formData.Add(new StringContent(dishEdit.Name), "Name");
        formData.Add(new StringContent(dishEdit.Description), "Description");
        formData.Add(new StringContent(dishEdit.Price.ToString()), "Price");

        var file = dishEdit.FileForm;
        if (file != null)
        {
            var fileFormContent = new StreamContent(file.OpenReadStream());
            formData.Add(fileFormContent, "FileForm", file.FileName);
        }

        var response = await httpClient.PostAsync("/Dish/dishEdit", formData);
        response.EnsureSuccessStatusCode();

        var contentResponse = response.Content.ReadAsStringAsync().Result;

        //if (response.IsSuccessStatusCode)
        //    return contentResponse;

        return true;
    }
}