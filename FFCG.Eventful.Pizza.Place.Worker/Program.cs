using System;
using FFCG.Eventful.Pizza.Place.Application.Interfaces;
using FFCG.Eventful.Pizza.Place.ServiceBus;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FFCG.Eventful.Pizza.Place.Cosmos.Providers;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Azure.Cosmos;

namespace FFCG.Eventful.Pizza.Place.Worker
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults(builder =>
                {
                    builder.Services.AddAzureClients(azureClientsBuilder =>
                    {
                        azureClientsBuilder.AddServiceBusClient(
                            Environment.GetEnvironmentVariable("ServiceBusConnectionStringOrders"));
                    });

                    const string cosmosConnString = "AccountEndpoint=https://ffcg-eventful-pizza-place.documents.azure.com:443/;AccountKey=Ohf1pAx3CEA5HXWv5JkWs6S4xaMXDdPdNm05jM6Qy2ydGTb10lohnym7Z74RtyWln2DRif1d4difA8kGSVRFKw==;";

                    builder.Services.AddScoped<IMessagingClient, ServiceBusSenderService>();
                    builder.Services.AddScoped<IOrderProvider, OrderProvider>();

                    builder.Services.AddSingleton(s => new CosmosClientBuilder(cosmosConnString)
                    .WithConnectionModeDirect()
                    .WithSerializerOptions(new CosmosSerializationOptions
                    {
                    PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
                    })
                    .Build());


                }).Build();



            


            host.Run();
        }

    }
}