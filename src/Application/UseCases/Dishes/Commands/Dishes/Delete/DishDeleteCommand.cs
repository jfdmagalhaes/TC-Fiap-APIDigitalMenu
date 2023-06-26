using MediatR;

namespace Application.UseCases.Dishes.Commands.Dishes.Delete;
public class DishDeleteCommand : IRequest<DishDeleteResponse>
{
    public int Id { get; set; }
}