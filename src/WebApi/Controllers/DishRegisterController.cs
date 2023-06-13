using Application.UseCases.Dishes.Commands.Create;
using Application.UseCases.Dishes.Commands.Get;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DishRegisterController : ControllerBase
{
    private readonly IMediator _mediator;

    public DishRegisterController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    /// <summary>
    /// Register a new dish
    /// </summary>
    /// <param name="command"></param>
    [AllowAnonymous]
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<DishRegisterResponse> RegisterAsync([FromForm] DishRegisterCommand command, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Get all records
    /// </summary>
    /// <param></param>
    [AllowAnonymous]
    [HttpGet("getAllDishes")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<GetDishesResponse> GetAllDishesAsync(CancellationToken cancellationToken = default)
    {
        return null;
        //return await _mediator. Send();
    }
}