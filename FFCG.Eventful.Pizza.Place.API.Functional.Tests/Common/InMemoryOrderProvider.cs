using FFCG.Eventful.Pizza.Place.Domain.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;

namespace FFCG.Eventful.Pizza.Place.API.Functional.Tests.Common;

public class InMemoryOrderProvider(IEnumerable<Order> items) : IOrderProvider
{
	public List<Order> Items { get; init; } = items.ToList();

	public Task<Order> GetOrderById(Guid id)
	{
		return Task.FromResult(Items.SingleOrDefault(x => x.Id == id));
	}

	public Task<IEnumerable<Order>> GetAllOrders()
	{
		return Task.FromResult(Items.AsEnumerable());
	}

	public Task<Order> UpsertOrder(Order order)
	{
		Items.Remove(Items.SingleOrDefault(x => x.Id == order.Id));
		Items.Add(order);
		return Task.FromResult(order);
	}
}
