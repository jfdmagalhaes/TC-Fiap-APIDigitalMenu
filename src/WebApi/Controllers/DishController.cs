using Application.UseCases.Dishes.Commands.Dishes.Create;
using Application.UseCases.Dishes.Commands.Dishes.Delete;
using Application.UseCases.Dishes.Commands.Dishes.Get;
using Application.UseCases.Dishes.Commands.Dishes.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DishController : ControllerBase
{
    private readonly IMediator _mediator;

    public DishController(IMediator mediator)
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
    public async Task<GetDishesResponse> GetAllDishesAsync([FromQuery] GetDishesCommand command, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Get all records
    /// </summary>
    /// <param></param>
    [AllowAnonymous]
    [HttpGet("getDishById")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<GetDishByIdResponse> GetDishByIdAsync ([FromQuery] GetDishByIdCommand command, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Edit an existing dish
    /// </summary>
    /// <param></param>
    [AllowAnonymous]
    [HttpPut("dishEdit")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<DishEditResponse> DishEditAsync([FromForm] DishEditCommand command, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Delete an existing dish
    /// </summary>
    /// <param></param>
    [AllowAnonymous]
    [HttpDelete("dishDelete")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<DishDeleteResponse> DishDeleteAsync([FromQuery] DishDeleteCommand command, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(command, cancellationToken);
    }
}