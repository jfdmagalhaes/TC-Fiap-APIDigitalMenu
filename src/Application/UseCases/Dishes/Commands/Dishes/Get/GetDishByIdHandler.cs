using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Dishes.Commands.Dishes.Get;
public class GetDishByIdHandler : IRequestHandler<GetDishByIdCommand, GetDishByIdResponse>
{
    private readonly IDishRepository _dishRepository;
    private readonly IAzureStorageRepository _azureStorageRepository;

    public GetDishByIdHandler(IDishRepository dishRepository, IAzureStorageRepository azureStorageRepository)
    {
        _dishRepository = dishRepository ?? throw new ArgumentNullException(nameof(dishRepository));
        _azureStorageRepository = azureStorageRepository ?? throw new ArgumentNullException(nameof(azureStorageRepository));
    }

    public async Task<GetDishByIdResponse> Handle(GetDishByIdCommand request, CancellationToken cancellationToken)
    {
        var dish = await _dishRepository.GetDishByIdAsync(request.Id);
        if (dish is null) throw new KeyNotFoundException("Não foi encontrado um prato com esse ID");
   
        var dishResponse = new GetDishByIdResponse()
        {
            Id = dish.Id,
            Description = dish.Description,
            Price = dish.Price,
            Name = dish.Name,
        };

        if (dish.AttachmentName != null)
        {
            var fileData = await _azureStorageRepository.DownloadAsync(dish.AttachmentName);
            dishResponse.UriFile = fileData.Uri;
        }

        return dishResponse;
    }
}