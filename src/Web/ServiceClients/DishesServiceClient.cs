﻿using Newtonsoft.Json;
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

    public async Task<DishEditViewModel> GetDishById(int id)
    {
        var httpClient = _httpClientFactory.CreateClient("DishesServiceClient");

        var response = await httpClient.GetAsync($"/Dish/getDishById?Id={id}");
        response.EnsureSuccessStatusCode();

        var dishFounded = new DishEditViewModel();
        if (response.IsSuccessStatusCode)
        {
            var stringData = await response.Content.ReadAsStringAsync();
            dishFounded = JsonConvert.DeserializeObject<DishEditViewModel>(stringData);
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
        formData.Add(new StringContent(dishEdit.Id.ToString()), "Id");

        var file = dishEdit.FileForm;
        if (file != null)
        {
            var fileFormContent = new StreamContent(file.OpenReadStream());
            formData.Add(fileFormContent, "FileForm", file.FileName);
        }

        var response = await httpClient.PutAsync("/Dish/dishEdit", formData);
        if (response.IsSuccessStatusCode) 
            return true;

        return false;
    }

    public async Task<bool> DishDelete(int id)
    {
        var httpClient = _httpClientFactory.CreateClient("DishesServiceClient");

        var response = await httpClient.DeleteAsync($"/Dish/dishDelete?Id={id}");

        if (response.IsSuccessStatusCode)
            return true;

        return false;
    }

    public async Task<bool> AddCartAsync(DishEditViewModel dish)
    {
        var httpClient = _httpClientFactory.CreateClient("DishesServiceClient");

        MultipartFormDataContent formData = new();

        formData.Add(new StringContent(dish.Id.ToString()), "DishId");
        formData.Add(new StringContent(dish.Price.ToString()), "Price");

        var response = await httpClient.PostAsync("/Dish/addItemOnCart", formData);
        response.EnsureSuccessStatusCode();

        if (response.IsSuccessStatusCode)
            return true;

        return false;
    }

    public async Task<DishCartViewModel> GetAllDishesCart()
    {
        var httpClient = _httpClientFactory.CreateClient("DishesServiceClient");

        var response = await httpClient.GetAsync("/Dish/getAllDishesCart");
        response.EnsureSuccessStatusCode();

        var allDishes = new DishCartViewModel();
        if (response.IsSuccessStatusCode)
        {
            var stringData = await response.Content.ReadAsStringAsync();
            allDishes = JsonConvert.DeserializeObject<DishCartViewModel>(stringData);
        }

        return allDishes;
    }

    public async Task<bool> DeleteAllDishesCart()
    {
        var httpClient = _httpClientFactory.CreateClient("DishesServiceClient");

        var response = await httpClient.DeleteAsync($"/Dish/dishCartDelete");

        if (response.IsSuccessStatusCode)
            return true;

        return false;
    }
}