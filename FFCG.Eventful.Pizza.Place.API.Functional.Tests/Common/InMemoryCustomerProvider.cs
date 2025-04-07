using FFCG.Eventful.Pizza.Place.Domain.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;

namespace FFCG.Eventful.Pizza.Place.API.Functional.Tests.Common;

public class InMemoryCustomerProvider(IEnumerable<Customer> items) : ICustomerProvider
{
	protected List<Customer> Items { get; init; } = items.ToList();

	public Task<Customer> GetCustomerById(Guid id)
	{
		var item = Items.FirstOrDefault(x => x.Id == id) ?? throw new KeyNotFoundException();
		return Task.FromResult(item);
	}

	public Task<IEnumerable<Customer>> GetAllCustomers()
	{
		return Task.FromResult(Items.AsEnumerable());
	}

	public Task<Customer> UpsertCustomer(Customer customer)
	{
		var item = Items.FirstOrDefault(x => x.Id == customer.Id);

		if (item is not null)
		{
			Items.Remove(item);
		}

		Items.Add(customer);
		return Task.FromResult(customer);
	}
}
