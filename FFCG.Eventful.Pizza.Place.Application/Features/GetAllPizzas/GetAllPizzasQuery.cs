using FFCG.Eventful.Pizza.Place.Domain.Interfaces;
using MediatR;

namespace FFCG.Eventful.Pizza.Place.Application.Features.GetAllPizzas;

public class GetAllPizzasQuery : IRequest<IEnumerable<Domain.Models.Pizza>> { }

public class GetAllPizzasHandler(IPizzaProvider provider) : IRequestHandler<GetAllPizzasQuery, IEnumerable<Domain.Models.Pizza>>
{
    public async Task<IEnumerable<Domain.Models.Pizza>> Handle(GetAllPizzasQuery request, CancellationToken cancellationToken)
        => await provider.GetAllPizzas();
}