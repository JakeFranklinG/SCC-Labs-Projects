using Cpt206.SqlServer;
namespace jGentryLab5_CPT206.Repositories
{
    public interface ICustomerRespository
    {
        //Crud operations for our interface
        Task<Customer?> CreateAsync(Customer c);
        Task<IEnumerable<Customer>> RetrieveAllAsync();
        Task<Customer?> RetrieveAsync(string id);
        Task<Customer?> UpdateAsync(string id, Customer c);
        Task<bool?> DeleteAsync(string id);
    }
}
