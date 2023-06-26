using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.UseCases.Dishes.Commands.Dishes.Update;
public class DishEditCommand : DishEntity, IRequest<DishEditResponse>
{
    public IFormFile FileForm { get; set; }
}