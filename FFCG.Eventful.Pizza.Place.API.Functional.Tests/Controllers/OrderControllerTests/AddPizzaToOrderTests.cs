using System.Net.Http.Json;
using FFCG.Eventful.Pizza.Place.API.Functional.Tests.Common;
using FFCG.Eventful.Pizza.Place.Domain.Models;

namespace FFCG.Eventful.Pizza.Place.API.Functional.Tests.Controllers.OrderControllerTests;

[TestFixture]
public class AddPizzaToOrderTests : TestDataSetUp
{
	protected override IEnumerable<Order> Orders { get; set; } = new List<Order>()
	{
		new ()
		{
			Id = Guid.NewGuid(),
			PizzaIds = []
		}
	};

	[Test]
	public async Task Should_Add_Pizza_To_Order()
	{
		// Arrange
		var pizzaId = Guid.NewGuid();

		// Act
		var response = await Client.PostAsJsonAsync(
			$"orders/{Orders.First().Id}/addPizza",
			pizzaId.ToString());

		// Assert
		response.EnsureSuccessStatusCode();
	}
}
