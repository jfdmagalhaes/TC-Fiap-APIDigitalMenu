using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Dishes.Commands.Dishes.Create;
public class DishRegisterHandler : IRequestHandler<DishRegisterCommand, DishRegisterResponse>, IDisposable
{
    private readonly IDishRepository _dishRepository;
    private readonly IMapper _mapper;
    private readonly IAzureStorageRepository _azureStorageRepository;

    public DishRegisterHandler(
        IDishRepository dishRepository,
        IMapper mapper,
        IAzureStorageRepository azureStorageRepository)
    {
        _dishRepository = dishRepository ?? throw new ArgumentNullException(nameof(dishRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _azureStorageRepository = azureStorageRepository ?? throw new ArgumentNullException(nameof(azureStorageRepository));
    }

    public async Task<DishRegisterResponse> Handle(DishRegisterCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var responseUploadAttachment = new Domain.Dto.BlobResponseDto();

            if (request.FileForm != null)
                responseUploadAttachment = await _azureStorageRepository.UploadAsync(request.FileForm);

            var dish = _mapper.Map<DishEntity>(request);
            dish.SetAttachmentName(responseUploadAttachment.Blob.FileName);

            await _dishRepository.AddDishAsync(dish);
            await _dishRepository.UnitOfWork.CommitAsync();

            return new DishRegisterResponse(dish.Id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    private bool _disposedValue = false;

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        Dispose(true);
    }

    public void Dispose(bool disposing)
    {
        if (_disposedValue) return;
        if (disposing)
        {
            _dishRepository.Dispose();
        }
        _disposedValue = true;
    }
}