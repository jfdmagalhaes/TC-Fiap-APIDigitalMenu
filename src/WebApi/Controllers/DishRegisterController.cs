using Application.UseCases.Dishes.Commands;
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
}