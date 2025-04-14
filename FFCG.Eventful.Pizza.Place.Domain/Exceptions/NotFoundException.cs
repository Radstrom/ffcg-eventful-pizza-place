namespace FFCG.Eventful.Pizza.Place.Domain.Exceptions;

public sealed class NotFoundException(string message) : Exception(message);
