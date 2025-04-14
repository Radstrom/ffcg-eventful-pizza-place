using System.Net;
using FFCG.Eventful.Pizza.Place.API.Functional.Tests.Common;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using Shouldly;

namespace FFCG.Eventful.Pizza.Place.API.Functional.Tests.Controllers.OrderControllerTests;

[TestFixture]
public class GetOrderByIdTestsWhenOrderCouldNotBeFound : TestDataSetUp
{
	protected override IEnumerable<Order> Orders { get; set; } = new List<Order>();

	[Test]
	public async Task Should_Get_Order_By_Id()
	{
		// Act
		var response = await Client.GetAsync($"orders/{Guid.NewGuid()}");

		// Assert
		response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
	}
}
