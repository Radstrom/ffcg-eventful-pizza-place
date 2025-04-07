using System.Net;
using FFCG.Eventful.Pizza.Place.API.Functional.Tests.Common;
using Shouldly;

namespace FFCG.Eventful.Pizza.Place.API.Functional.Tests.Controllers.OrderControllerTests;

[TestFixture]
public class GetOrderByIdTestsWhenOrderIsEmpty : TestDataSetUp
{
	[Test]
	public async Task Should_Get_Order_By_Id()
	{
		// Act
		var response = await Client.GetAsync($"orders/{Guid.Empty}");

		// Assert
		response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
	}
}
