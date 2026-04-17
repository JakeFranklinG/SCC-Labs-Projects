using Microsoft.EntityFrameworkCore.ChangeTracking;
using Cpt206.SqlServer;
using System.Collections.Concurrent;

namespace jGentryLab5_CPT206.Repositories
{
    public class CustomerRepository : ICustomerRespository
    {
        //create a cache to store the customers in memory
        private static ConcurrentDictionary<string, Customer>? customerCache;

        private NorthwindContext db;

        public CustomerRepository(NorthwindContext _db)
        {
            db = _db;

            if (customerCache == null)
            {
                //fill the cache with the database info
                customerCache = new ConcurrentDictionary<string, Customer>(
                    db.Customers.ToDictionary(c => c.CustomerId));
            }
        }

        public async Task<Customer?> CreateAsync(Customer c)
        {
            //normalizing the id
            c.CustomerId = c.CustomerId.ToUpper();

            //add to database
            EntityEntry<Customer> added = await db.Customers.AddAsync(c);

            //affected number of rows changed in the database
            int affected = await db.SaveChangesAsync();

            if (affected == 1)
            {
                if (customerCache is null)
                {
                    return c;
                }
                else
                {
                    //update the cache
                    return customerCache.AddOrUpdate(c.CustomerId, c, UpdateCache);
                }
            }
            else return null;
        }

        //retrieve all info from the cache instead of database
        public Task<IEnumerable<Customer>> RetrieveAllAsync()
        {
            return Task.FromResult(customerCache is null
                ? Enumerable.Empty<Customer>()
                : customerCache.Values);
        }

        public Task<Customer?> RetrieveAsync(string id)
        {
            // for performance, get from cache
            id = id.ToUpper();

            if (customerCache is null) return null!;

            customerCache.TryGetValue(id, out Customer? c);

            return Task.FromResult(c);
        }

        private Customer UpdateCache(string id, Customer customer)
        {
            Customer? old;
            if (customerCache is not null)
            {
                if (customerCache.TryGetValue(id, out old))
                {
                    if (customerCache.TryUpdate(id, customer, old))
                    {
                        return customer;
                    }
                }
            }
            return null!;
        }

        public async Task<Customer?> UpdateAsync(string id, Customer customer)
        {
            // normalize customer Id
            id = id.ToUpper();
            customer.CustomerId = customer.CustomerId.ToUpper();

            // update in database
            db.Customers.Update(customer);

            int affected = await db.SaveChangesAsync();

            if (affected == 1)
            {
                // update in cache
                return UpdateCache(id, customer);
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(string id)
        {
            id = id.ToUpper();

            // remove from database
            Customer? c = db.Customers.Find(id);

            if (c is null) return null;

            db.Customers.Remove(c);

            int affected = await db.SaveChangesAsync();

            if (affected == 1)
            {
                if (customerCache is null) return null;
                // remove from cache
                return customerCache.TryRemove(id, out c);
            }
            else
            {
                return null;
            }
        }
    }
}
