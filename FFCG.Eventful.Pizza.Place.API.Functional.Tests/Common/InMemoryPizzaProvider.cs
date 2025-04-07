using FFCG.Eventful.Pizza.Place.Domain.Interfaces;

namespace FFCG.Eventful.Pizza.Place.API.Functional.Tests.Common;

public class InMemoryPizzaProvider(IEnumerable<Domain.Models.Pizza> items) : IPizzaProvider
{
	protected List<Domain.Models.Pizza> Items { get; init; } = items.ToList();

	public Task<Domain.Models.Pizza> GetPizzaById(Guid id)
	{
		var item = Items.FirstOrDefault(x => x.Id == id) ?? throw new KeyNotFoundException();
		return Task.FromResult(item);
	}

	public Task<IEnumerable<Domain.Models.Pizza>> GetAllPizzas()
	{
		return Task.FromResult(Items.AsEnumerable());
	}

	public Task<Domain.Models.Pizza> UpsertPizza(Domain.Models.Pizza pizza)
	{
		var item = Items.FirstOrDefault(x => x.Id == pizza.Id);

		if (item is not null)
		{
			Items.Remove(item);
		}

		Items.Add(pizza);
		return Task.FromResult(pizza);
	}
}
