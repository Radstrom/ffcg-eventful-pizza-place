using System.Net;
using System.Net.Http.Json;
using FFCG.Eventful.Pizza.Place.API.Controllers.Pizzas.ApiModels;
using FFCG.Eventful.Pizza.Place.API.Functional.Tests.Common;
using Shouldly;

namespace FFCG.Eventful.Pizza.Place.API.Functional.Tests.PizzaControllerTests;

[TestFixture]
public class CreatePizzaTests : TestDataSetUp
{
	[Test]
	[Order(1)]
	public async Task Should_Create_Pizza()
	{
		// Arrange
		List<ToppingApiModel> toppings =
		[
			new("Ost", 5),
			new("Oxfilé", 20)
		];
		var pizza = new CreateNewPizzaApiModel("Ciao ciao", toppings);

		// Act
		var response = await Client.PostAsJsonAsync(
			"pizzas/",
			pizza);

		// Assert
		response.EnsureSuccessStatusCode();
		response.StatusCode.ShouldBe(HttpStatusCode.Created);
	}

	[Test]
	[Order(2)]
	public async Task Should_Create_Order()
	{

	}

	[Test]
	[Order(3)]
	public async Task Should_Add_Customer_To_Order()
	{

	}

	[Test]
	[Order(4)]
	public async Task Should_Add_Pizza_To_Order()
	{

	}

	[Test]
	[Order(5)]
	public async Task Should_Get_Customer()
	{
		// Assert
		// Rätt order med rätt pizza finns på användaren
	}
}
