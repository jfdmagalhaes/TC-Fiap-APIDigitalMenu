using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Dishes.Commands.Get;
public class GetDishesHandler : IRequestHandler<GetDishesCommand, GetDishesResponse>
{
    private readonly IDishRepository _dishRepository;
    private readonly IAzureStorageRepository _azureStorageRepository;

    public GetDishesHandler(IDishRepository dishRepository, IAzureStorageRepository azureStorageRepository)
    {
        _dishRepository = dishRepository ?? throw new ArgumentNullException(nameof(dishRepository));
        _azureStorageRepository = azureStorageRepository ?? throw new ArgumentNullException(nameof(azureStorageRepository));
    }

    public async Task<GetDishesResponse> Handle(GetDishesCommand request, CancellationToken cancellationToken)
    {
        var allDishes = await _dishRepository.GetAllDishesAsync();
        var dishResponse = new GetDishesResponse();

        foreach (var dish in allDishes)
        {
            var response = new DishResponse()
            {
                Id = dish.Id,
                Description = dish.Description,
                Name = dish.Name,
                Price = dish.Price
            };

            if (dish.Anexo != null)
            {
                var fileData = await _azureStorageRepository.DownloadAsync(dish.Anexo);
                response.UriFile = fileData.Uri;
            }

            dishResponse.Dishes.Add(response);
        }

        return dishResponse;
    }
}