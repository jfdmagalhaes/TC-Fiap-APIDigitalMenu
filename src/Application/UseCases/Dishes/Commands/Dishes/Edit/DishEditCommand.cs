using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.UseCases.Dishes.Commands.Dishes.Edit;
public class DishEditCommand : DishEntity, IRequest<DishEditResponse>
{
    public IFormFile FileForm { get; set; }
}