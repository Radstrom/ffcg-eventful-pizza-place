using System;
using FFCG.Eventful.Pizza.Place.Application.Interfaces;
using FFCG.Eventful.Pizza.Place.ServiceBus;
using Microsoft.Azure.Functions.Worker;


namespace FFCG.Eventful.Pizza.Place.Worker.Functions.ProcessIncomingOrder;

public class ProcessIncomingOrderFunction
{

    private readonly IOrderProvider orderProvider;

    public ProcessIncomingOrderFunction(IOrderProvider iorderProvider)
    {
        orderProvider = iorderProvider;
    }


    [Function(nameof(ProcessIncomingOrderFunction))]
    public void Run(
        [ServiceBusTrigger(Topics.Orders, "worker-incoming-order-grupp2", Connection = "ServiceBusConnectionStringOrders")] IncomingOrderMessage incomingOrder)
    {

        orderProvider.UpsertOrder(new Domain.Models.Order());


        Console.WriteLine("Order körs");
    }
}