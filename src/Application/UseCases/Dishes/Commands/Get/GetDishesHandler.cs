using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Dishes.Commands.Get;
public class GetDishesHandler : IRequestHandler<GetDishesCommand, GetDishesResponse>
{
    private readonly IDishRepository _dishRepository;

    public GetDishesHandler(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository ?? throw new ArgumentNullException(nameof(dishRepository));
    }

    public async Task<GetDishesResponse> Handle(GetDishesCommand request, CancellationToken cancellationToken)
    {
        var allDishes = await _dishRepository.GetAllDishesAsync();
        var response = new GetDishesResponse();

        response.Dishes.AddRange(allDishes);
        return response;
    }
}