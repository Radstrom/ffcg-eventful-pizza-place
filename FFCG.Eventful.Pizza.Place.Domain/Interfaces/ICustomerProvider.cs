using FFCG.Eventful.Pizza.Place.Domain.Models;

namespace FFCG.Eventful.Pizza.Place.Domain.Interfaces;

public interface ICustomerProvider
{
    public Task<Customer> GetCustomerById(Guid id);
    public Task<IEnumerable<Customer>> GetAllCustomers();
    public Task<Customer> UpsertCustomer(Customer customer);
}