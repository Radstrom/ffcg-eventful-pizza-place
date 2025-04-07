using FakeItEasy;
using FFCG.Eventful.Pizza.Place.Domain.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace FFCG.Eventful.Pizza.Place.API.Functional.Tests.Common;

public abstract class TestDataSetUp : TestBase
{
    protected readonly IMessagingClient MessagingClient = A.Fake<IMessagingClient>();
    protected virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
    protected virtual IEnumerable<Customer> Customers { get; set; } = new List<Customer>();
    protected virtual IEnumerable<Domain.Models.Pizza> Pizzas { get; set; } = new List<Domain.Models.Pizza>();

    protected InMemoryOrderProvider? OrderProvider { get; set; }
    protected InMemoryCustomerProvider? CustomerProvider { get; set; }
    protected InMemoryPizzaProvider? PizzaProvider { get; set; }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
	    ConfigureClient(services =>
	    {
		    OrderProvider = new InMemoryOrderProvider(Orders);
		    CustomerProvider = new InMemoryCustomerProvider(Customers);
		    PizzaProvider = new InMemoryPizzaProvider(Pizzas);

            services.AddScoped(_ => MessagingClient);
            services.AddSingleton<IOrderProvider>(_ => OrderProvider);
            services.AddSingleton<ICustomerProvider>(_ => CustomerProvider);
            services.AddSingleton<IPizzaProvider>(_ => PizzaProvider);
        });
    }
}
