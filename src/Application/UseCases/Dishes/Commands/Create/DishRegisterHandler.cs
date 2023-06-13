using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Dishes.Commands.Create;
public class DishRegisterHandler : IRequestHandler<DishRegisterCommand, DishRegisterResponse>, IDisposable
{
    private readonly IDishRepository _dishRepository;
    private readonly IMapper _mapper;

    public DishRegisterHandler(IDishRepository dishRepository, IMapper mapper)
    {
        _dishRepository = dishRepository ?? throw new ArgumentNullException(nameof(dishRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<DishRegisterResponse> Handle(DishRegisterCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var dish = _mapper.Map<DishEntity>(request);
            await _dishRepository.AddDishAsync(dish);
            await _dishRepository.UnitOfWork.CommitAsync();

            //TODO enviar o anexo para o blobStorage - implementar
            //var fileStream = request.FileStream.OpenReadStream();

            return new DishRegisterResponse(dish.Id);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    private bool _disposedValue = false;

    public void Dispose() => Dispose(true);

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