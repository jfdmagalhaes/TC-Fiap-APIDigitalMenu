using Application.UseCases.Dishes.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers;
[ApiController]
public class DishRegisterController : Controller
{
    /// <summary>
    /// Register a new dish
    /// </summary>
    /// <param name="command"></param>
    [AllowAnonymous]
    [HttpPost("register")]
    //[ProducesResponseType(StatusCodes.Status201Created)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterCommand command)
    {
        var teste = command;
        return null;
    }
}