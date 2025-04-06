using FFCG.Eventful.Pizza.Place.Domain.Interfaces;
using MediatR;

namespace FFCG.Eventful.Pizza.Place.Application.Features.GetPizzaById;

public record GetPizzaByIdQuery(Guid Id) : IRequest<Domain.Models.Pizza>;

public class GetPizzaByIdHandler(IPizzaProvider provider) : IRequestHandler<GetPizzaByIdQuery, Domain.Models.Pizza>
{
    public async Task<Domain.Models.Pizza> Handle(GetPizzaByIdQuery request, CancellationToken cancellationToken)
        => await provider.GetPizzaById(request.Id);
}