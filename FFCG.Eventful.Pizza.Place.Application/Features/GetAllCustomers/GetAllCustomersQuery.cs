using FFCG.Eventful.Pizza.Place.Domain.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using MediatR;

namespace FFCG.Eventful.Pizza.Place.Application.Features.GetAllCustomers;

public class GetAllCustomersQuery : IRequest<IEnumerable<Customer>> { }

public class GetAllCustomersHandler(ICustomerProvider provider) : IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
{
    public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        => await provider.GetAllCustomers();
}