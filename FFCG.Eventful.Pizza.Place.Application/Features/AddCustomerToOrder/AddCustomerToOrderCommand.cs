using FFCG.Eventful.Pizza.Place.Domain.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using MediatR;

namespace FFCG.Eventful.Pizza.Place.Application.Features.AddCustomerToOrder;

public record AddCustomerToOrderCommand(Guid OrderId, Guid CustomerId) : IRequest<Order>;

public class AddCustomerToOrderHandler(IOrderProvider orderProvider) : IRequestHandler<AddCustomerToOrderCommand, Order>
{
    public async Task<Order> Handle(AddCustomerToOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await orderProvider.GetOrderById(request.OrderId);
        order.CustomerId = request.CustomerId;

        await orderProvider.UpsertOrder(order);

        return order;
    }
}