using FFCG.Eventful.Pizza.Place.Domain.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using MediatR;

namespace FFCG.Eventful.Pizza.Place.Application.Features.GetAllOrders;

public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
{
    
}

public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
{
    private readonly IOrderProvider _orderProvider;

    public GetAllOrdersHandler(IOrderProvider orderProvider)
    {
        _orderProvider = orderProvider;
    }

    public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var result = await _orderProvider.GetAllOrders();

        return result;
    }
}