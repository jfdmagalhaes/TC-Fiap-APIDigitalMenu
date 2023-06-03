using MediatR;

namespace Application.UseCases.Dishes.Commands;
public class DishRegisterHandler : IRequestHandler<DishRegisterCommand, DishRegisterResponse>
{
    public Task<DishRegisterResponse> Handle(DishRegisterCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
