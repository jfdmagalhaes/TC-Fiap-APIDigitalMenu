using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Dishes.Commands;
public class DishRegisterHandler : IRequestHandler<DishRegisterCommand, DishRegisterResponse>
{
    private readonly IDishRepository _dishRepository;
    private readonly IMapper _mapper;

    public DishRegisterHandler(IDishRepository dishRepository, IMapper mapper)
    {
        _dishRepository = dishRepository ?? throw new ArgumentNullException(nameof(dishRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public Task<DishRegisterResponse> Handle(DishRegisterCommand request, CancellationToken cancellationToken)
    {
        //var fileStream = request.FileStream.OpenReadStream();
        var response = _dishRepository.AddDish(_mapper.Map<DishEntity>(request));

        throw new NotImplementedException();
    }
}
