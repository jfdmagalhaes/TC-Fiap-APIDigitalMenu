using MediatR;

namespace Application.UseCases.Dishes.Commands.Dishes.Get;
public class GetDishByIdCommand : IRequest<GetDishByIdResponse>
{
    public int Id { get; set; }
}
