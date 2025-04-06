using FFCG.Eventful.Pizza.Place.Domain.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using MediatR;

namespace FFCG.Eventful.Pizza.Place.Application.Features.CreateNewOrder;

public class CreateNewOrderCommand : IRequest<Order>
{

}

public class CreateNewOrderHandler(IOrderProvider orderProvider) : IRequestHandler<CreateNewOrderCommand, Order>
{
    public async Task<Order> Handle(CreateNewOrderCommand request, CancellationToken cancellationToken)
    {
        var result = await orderProvider.UpsertOrder(new Order());

        return result;
    }
}