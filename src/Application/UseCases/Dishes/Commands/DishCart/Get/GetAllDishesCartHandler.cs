using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Dishes.Commands.DishCart.Get;
public class GetAllDishesCartHandler : IRequestHandler<GetAllDishesCartCommand, GetAllDishesCartResponse>
{
    private readonly IDishRepository _dishRepository;

    public GetAllDishesCartHandler(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository ?? throw new ArgumentNullException(nameof(dishRepository));
    }

    public async Task<GetAllDishesCartResponse> Handle(GetAllDishesCartCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var dishesCart = await _dishRepository.GetAllDishesCartAsync();
            var response = new GetAllDishesCartResponse();

            foreach (var dishCart in dishesCart)
            {
                var getDish = await _dishRepository.GetDishByIdAsync(dishCart.DishId);

                response.Id = dishCart.CartId;
                response.DishItems.Add(new DishCartItems
                {
                    Name = getDish.Name,
                    Price = (decimal)dishCart.UnitPrice,
                    Quantity = dishCart.Quantity
                });
            }

            return response;
        } 
        catch (Exception)
        {
            throw;
        }
    }
}
