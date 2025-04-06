using FakeItEasy;
using FFCG.Eventful.Pizza.Place.Domain.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace FFCG.Eventful.Pizza.Place.API.Functional.Tests.Common;

public abstract class TestDataSetUp : TestBase
{
    protected readonly IMessagingClient MessagingClient = A.Fake<IMessagingClient>();
    protected virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
	    ConfigureClient(services =>
        {
            services.AddScoped(_ => MessagingClient);
            services.AddSingleton<IOrderProvider>(_ => new InMemoryOrderProvider(Orders));
        });
    }
}
