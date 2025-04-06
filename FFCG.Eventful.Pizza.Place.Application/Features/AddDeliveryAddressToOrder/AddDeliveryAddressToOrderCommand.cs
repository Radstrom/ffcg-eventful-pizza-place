using FFCG.Eventful.Pizza.Place.Domain.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using MediatR;

namespace FFCG.Eventful.Pizza.Place.Application.Features.AddDeliveryAddressToOrder;

public record AddDeliveryAddressToOrderCommand(Guid OrderId, Address DeliveryAddress) : IRequest<Order>;

public class AddDeliveryAddressToOrderHandler(IOrderProvider orderProvider) : IRequestHandler<AddDeliveryAddressToOrderCommand, Order>
{
    public async Task<Order> Handle(AddDeliveryAddressToOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await orderProvider.GetOrderById(request.OrderId);
        order.DeliveryAddress = request.DeliveryAddress;

        await orderProvider.UpsertOrder(order);

        return order;
    }
}