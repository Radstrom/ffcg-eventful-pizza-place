using FFCG.Eventful.Pizza.Place.Domain.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using MediatR;

namespace FFCG.Eventful.Pizza.Place.Application.Features.GetCustomerById;

public record GetCustomerByIdQuery(Guid Id) : IRequest<Customer>;

public class GetCustomerByIdHandler(ICustomerProvider provider) : IRequestHandler<GetCustomerByIdQuery, Customer>
{
    public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        => await provider.GetCustomerById(request.Id);
}