using System.Net.Http.Json;
using FFCG.Eventful.Pizza.Place.API.Functional.Tests.Common;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using Shouldly;

namespace FFCG.Eventful.Pizza.Place.API.Functional.Tests.Controllers.OrderControllerTests;

[TestFixture]
public class GetOrderByIdTests : TestDataSetUp
{
	protected override IEnumerable<Order> Orders { get; set; } = new List<Order>
	{
		new()
		{
			Id = Guid.NewGuid(),
			CustomerId = Guid.NewGuid(),
			PizzaIds =
			[
				Guid.NewGuid(),
				Guid.NewGuid()
			],
			DeliveryAddress = new Address
			{
				City = "City",
				Country = "Country",
				Street = "Street",
				ZipCode = "ZipCode",
				StreetNumber = "StreetNumber"
			}
		}
	};

	[Test]
	public async Task Should_Get_Order_By_Id()
	{
		// Arrange
		var order = Orders.First();

		// Act
		var response = await Client.GetFromJsonAsync<Order>($"orders/{order.Id}");

		// Assert
		response.ShouldNotBeNull();
		response.Id.ShouldBe(order.Id);
	}
}
