using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Dishes.Commands.DishCart.Delete;
public class DishCartDeleteHandler : IRequestHandler<DishCartDeleteCommand, DishCartDeleteResponse>
{
    private readonly IDishRepository _dishRepository;

    public DishCartDeleteHandler(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository ?? throw new ArgumentNullException(nameof(dishRepository));

    }
    public async Task<DishCartDeleteResponse> Handle(DishCartDeleteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var dishesCart = await _dishRepository.GetAllDishesCartAsync();

            _dishRepository.DeleteAllDishesCart(dishesCart);
            await _dishRepository.UnitOfWork.CommitAsync();

            return new DishCartDeleteResponse { Success = true };

        }
        catch (Exception ex)
        {
            return new DishCartDeleteResponse { Success = false };

        }

    }
}
