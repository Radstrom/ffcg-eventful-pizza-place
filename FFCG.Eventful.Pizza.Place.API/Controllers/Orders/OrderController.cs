using FFCG.Eventful.Pizza.Place.API.Controllers.Orders.ApiModels;
using FFCG.Eventful.Pizza.Place.Application.Features.AddCustomerToOrder;
using FFCG.Eventful.Pizza.Place.Application.Features.AddDeliveryAddressToOrder;
using FFCG.Eventful.Pizza.Place.Application.Features.AddPizzaToOrder;
using FFCG.Eventful.Pizza.Place.Application.Features.CreateNewOrder;
using FFCG.Eventful.Pizza.Place.Application.Features.GetAllOrders;
using FFCG.Eventful.Pizza.Place.Application.Features.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FFCG.Eventful.Pizza.Place.API.Controllers.Orders;

[ApiController]
[Route("orders")]
public class OrderController(ISender mediatrSender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateNewOrderCommand command)
    {
        var result = await mediatrSender.Send(command);
        return Created(result.Id.ToString(), result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var result = await mediatrSender.Send(new GetAllOrdersQuery());
        return Ok(result);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetOrderById(Guid id)
    {
	    if (id == Guid.Empty)
	    {
		    return BadRequest();
	    }

        var result = await mediatrSender.Send(new GetOrderByIdQuery(id));
        return Ok(result);
    }

    [HttpPost]
    [Route("{id:guid}/addPizza")]
    public async Task<IActionResult> AddPizzaToOrder(Guid id, [FromBody] Guid pizzaId)
    {
        return Ok(await mediatrSender.Send(new AddPizzaToOrderCommand(id, pizzaId)));
    }

    [HttpPost]
    [Route("{id:guid}/addCustomer")]
    public async Task<IActionResult> AddCustomerToOrder(Guid id, [FromBody] Guid customerId)
    {
        return Ok(await mediatrSender.Send(new AddCustomerToOrderCommand(id, customerId)));
    }

    [HttpPost]
    [Route("{id:guid}/addDeliveryAddress")]
    public async Task<IActionResult> AddDeliveryAddressToOrder(Guid id, [FromBody] AddDeliveryAddressToOrderApiModel model)
    {
        return Ok(await mediatrSender.Send(new AddDeliveryAddressToOrderCommand(id, model.MapToEntity())));
    }
}
