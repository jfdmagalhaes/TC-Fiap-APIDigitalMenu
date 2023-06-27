using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Dishes.Commands.DishCart.Create;
public class DishCartHandler : IRequestHandler<DishCartCommand, DishCartResponse>
{
    private readonly IDishRepository _dishRepository;

    public DishCartHandler(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository ?? throw new ArgumentNullException(nameof(dishRepository));
    }

    public async Task<DishCartResponse> Handle(DishCartCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var dishCart = new DishCartEntity()
            {
                Quantity = request.Quantity,
                UnitPrice = request.Price,
                DishId = request.DishId
            };

            await _dishRepository.AddDishCart(dishCart);
            await _dishRepository.UnitOfWork.CommitAsync();

            return new DishCartResponse
            {
                CartId = dishCart.CartId,
                Quantity = dishCart.Quantity,
                DishId = dishCart.DishId,
                UnitPrice = dishCart.UnitPrice
            };
        }
        catch (Exception)
        {
            throw;
        }

    }
}
