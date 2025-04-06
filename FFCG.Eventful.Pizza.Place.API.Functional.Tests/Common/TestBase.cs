using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace FFCG.Eventful.Pizza.Place.API.Functional.Tests.Common;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
	"NUnit1032:An IDisposable field/property should be Disposed in a TearDown method",
	Justification = "Reason...")]

public class TestBase
{
    protected HttpClient Client = new ();

    protected void ConfigureClient(Action<IServiceCollection>? registrations = null)
    {
        var app = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {

                registrations?.Invoke(services);
            }).UseEnvironment("Testing");
        });

        Client = app.CreateClient(new WebApplicationFactoryClientOptions
        {
            BaseAddress = new Uri("http://localhost/")
        });
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        Client.Dispose();
    }
}
