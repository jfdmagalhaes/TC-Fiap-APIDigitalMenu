using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.UseCases.Dishes.Commands.Create;
public class DishRegisterCommand : IRequest<DishRegisterResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Value { get; set; }
    public IFormFile FileStream { get; set; }
}