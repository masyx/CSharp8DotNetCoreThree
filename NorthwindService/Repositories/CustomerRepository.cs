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
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<Customer>> RetrieveAllAsync()
        {
            // for performace, get from cache
            return Task.Run<IEnumerable<Customer>>(() => _customerCache.Values);
        }

        public Task<Customer> RetrieveAsync(string id)
        {
            return Task.Run(() =>
            {
                // for performance get from cache
                id = id.ToUpper();
                _customerCache.TryGetValue(id, out Customer c);
                return c;
            });
        }

        public async Task<Customer> UpdateAsync(string id, Customer c)
        {
            // normalize customer id
            id = id.ToUpper();
            c.CustomerID = c.CustomerID.ToUpper();

            // update in db
            db.Customers.Update(c);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                // update in cache
                UpdateCache(id, c);
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(string id)
        {
            id = id.ToUpper();

            var c = db.Customers.Find(id);
            db.Customers.Remove(c);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return _customerCache.TryRemove(id, out c);
            }
            return null;
        }

        private Customer UpdateCache(string id, Customer c)
        {
            Customer old;
            if (_customerCache.TryGetValue(id, out old))
            {
                if (_customerCache.TryUpdate(id, c, old))
                {
                    return c;
                }
            }
            return null;
        }
    }
}
