using System;
using System.Collections.Generic;
using Packt.Shared;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace NorthwindService.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        //use static thread-safe dictionary field to cache the customers
        private static ConcurrentDictionary<string, Customer> _customerCache;

        // use an instance data context field because it should not be
        // cached due to their internal caching
        private Northwind db;

        public CustomerRepository(Northwind db)
        {
            this.db = db;

            // pre-load customers from database as a normal
            // Dictionary with CustomerID as the key,
            // then convert to a thread-safe ConcurrentDictionary
            if (_customerCache == null)
            {
                _customerCache = new ConcurrentDictionary<string, Customer>(db.Customers
                    .ToDictionary(customer => customer.CustomerID));
            }
        }

        public async Task<Customer> CreateAsync(Customer c)
        {
            // normolize CustomerID into uppercase    
            c.CustomerID = c.CustomerID.ToUpper();

            EntityEntry<Customer> added = await db.Customers.AddAsync(c);
            var affected = await db.SaveChangesAsync();

            if (affected == 1)
            {
                return _customerCache.AddOrUpdate(c.CustomerID, c, UpdateCache);
            }
        }

        public Task<bool?> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> RetrieveAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> RetrieveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateAsync(string id, Customer c)
        {
            throw new NotImplementedException();
        }
    }
}
