using FFCG.Eventful.Pizza.Place.Domain.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using FFCG.Eventful.Pizza.Place.Domain.Services;
using MediatR;

namespace FFCG.Eventful.Pizza.Place.Application.Features.CreateNewPizza;

public class CreateNewPizzaCommand : IRequest<Domain.Models.Pizza>
{
    public required string Name { get; init; }
    public required List<Topping> Toppings { get; init; }
}

public class CreateNewPizzaHandler(IPizzaProvider pizzaProvider, IPizzaService pizzaService) : IRequestHandler<CreateNewPizzaCommand, Domain.Models.Pizza>
{
    public async Task<Domain.Models.Pizza> Handle(CreateNewPizzaCommand request, CancellationToken cancellationToken)
    {
        var pizza = await pizzaService.Create(request.Name, request.Toppings);
        return await pizzaProvider.UpsertPizza(pizza);
    }
}