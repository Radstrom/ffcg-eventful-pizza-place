using FFCG.Eventful.Pizza.Place.Domain.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using MediatR;

namespace FFCG.Eventful.Pizza.Place.Application.Features.AddPizzaToOrder;

public record AddPizzaToOrderCommand(Guid OrderId, Guid PizzaId) : IRequest<Order>;

public class AddPizzaToOrderHandler(IOrderProvider orderProvider) : IRequestHandler<AddPizzaToOrderCommand, Order>
{
    public async Task<Order> Handle(AddPizzaToOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await orderProvider.GetOrderById(request.OrderId);
        order.PizzaIds.Add(request.PizzaId);

        await orderProvider.UpsertOrder(order);

        return order;
    }
}