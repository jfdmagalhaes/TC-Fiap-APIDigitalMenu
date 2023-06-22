using Application.UseCases.Dishes.Commands.Dishes.Create;
using AutoMapper;
using Domain.Entities;

namespace WebApi.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<DishRegisterCommand,
            DishEntity>().ReverseMap();
    }
}