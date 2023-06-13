using Application.UseCases.Dishes.Commands.Create;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Dishes.Commands.Get;
public class GetDishesHandler : IRequestHandler<GetDishesCommand, GetDishesResponse>
{
    public async Task<GetDishesResponse> Handle(GetDishesCommand request, CancellationToken cancellationToken)
    {
        var teste = new DishEntity();
        var response = new GetDishesResponse();
        response.Dishes.Add(teste);


        return response;

        //throw new NotImplementedException();
    }
}
