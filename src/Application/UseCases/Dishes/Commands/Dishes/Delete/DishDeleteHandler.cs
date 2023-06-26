using Application.UseCases.Dishes.Commands.Dishes.Update;
using Domain.Interfaces;
using MediatR;
using System.Text;

namespace Application.UseCases.Dishes.Commands.Dishes.Delete;
public class DishDeleteHandler : IRequestHandler<DishDeleteCommand, DishDeleteResponse>
{
    private readonly IDishRepository _dishRepository;
    private readonly IAzureStorageRepository _azureStorageRepository;

    public DishDeleteHandler(
        IDishRepository dishRepository,
        IAzureStorageRepository azureStorageRepository)
    {
        _dishRepository = dishRepository ?? throw new ArgumentNullException(nameof(dishRepository));
        _azureStorageRepository = azureStorageRepository ?? throw new ArgumentNullException(nameof(azureStorageRepository));
    }

    public async Task<DishDeleteResponse> Handle(DishDeleteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var response = new DishDeleteResponse();

            var getDish = await _dishRepository.GetDishByIdAsync(request.Id);
            if (getDish is null) return response;


            if (getDish.AttachmentName is not null)          
                await _azureStorageRepository.DeleteAsync(getDish.AttachmentName);
            
            _dishRepository.DeleteDish(getDish);
            await _dishRepository.UnitOfWork.CommitAsync();

            return new DishDeleteResponse { Success = true };
        }
        catch (Exception)
        {
            return new DishDeleteResponse { Success = false };

        }
    }
}