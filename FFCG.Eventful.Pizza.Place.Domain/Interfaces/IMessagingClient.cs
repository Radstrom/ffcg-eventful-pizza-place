namespace FFCG.Eventful.Pizza.Place.Domain.Interfaces;

public interface IMessagingClient
{
    public Task<bool> SendMessage<T>(string subject, T data);
}