namespace FFCG.Eventful.Pizza.Place.Domain.Interfaces;

public interface IPizzaProvider
{
    public Task<Domain.Models.Pizza> GetPizzaById(Guid id);
    public Task<IEnumerable<Domain.Models.Pizza>> GetAllPizzas();
    public Task<Domain.Models.Pizza> UpsertPizza(Domain.Models.Pizza pizza);
}