using FFCG.Eventful.Pizza.Place.API.Controllers.Customers.ApiModels;
using FFCG.Eventful.Pizza.Place.Application.Features.GetAllCustomers;
using FFCG.Eventful.Pizza.Place.Application.Features.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FFCG.Eventful.Pizza.Place.API.Controllers.Customers;

[ApiController]
[Route("customers")]
public class CustomerController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateNewCustomerApiModel model)
    {
        var result = await sender.Send(model.MapToCommand());
        return Created(result.Id.ToString(), result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
        => Ok(await sender.Send(new GetAllCustomersQuery()));

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetCustomerById(Guid id)
        => Ok(await sender.Send(new GetCustomerByIdQuery(id)));
}