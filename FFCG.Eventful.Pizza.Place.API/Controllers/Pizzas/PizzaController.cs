using FFCG.Eventful.Pizza.Place.API.Controllers.Pizzas.ApiModels;
using FFCG.Eventful.Pizza.Place.Application.Features.GetAllPizzas;
using FFCG.Eventful.Pizza.Place.Application.Features.GetPizzaById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FFCG.Eventful.Pizza.Place.API.Controllers.Pizzas;

[ApiController]
[Route("pizzas")]
public class PizzaController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePizza([FromBody] CreateNewPizzaApiModel model)
    {
        var result = await sender.Send(model.MapToCommand());
        return Created(result.Id.ToString(), result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPizzas()
    {
        return Ok(await sender.Send(new GetAllPizzasQuery()));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetPizzaById(Guid id)
    {
        return Ok(await sender.Send(new GetPizzaByIdQuery(id)));
    }
}
