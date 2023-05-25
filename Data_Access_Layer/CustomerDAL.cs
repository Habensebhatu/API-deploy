using System;
using Data_Access_Layer.Context;
using Data_Access_Layer.Data;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer
{
    public class CustomerDAL
    {
        private readonly MyDbContext _context;
        public CustomerDAL()
        {
            _context = new MyDbContext();
        }

        public async Task<CustomerEntityModel> AddCustomer(CustomerEntityModel customer)
        {
            _context.Client.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<List<CustomerEntityModel>> GetCustomers()
        {
            List<CustomerEntityModel> customers = await _context.Client.ToListAsync();
            return customers;
        }

        public async Task<CustomerEntityModel> GetCustomerById(Guid customerId)
        {
            return await _context.Client.FirstOrDefaultAsync(x => x.customerId == customerId);

        }

        public async Task<List<CustomerEntityModel>> SearchCustomers(string query)
        {
            return await _context.Client
                .Where(c => c.name.ToLower().Contains(query.ToLower()))
                .ToListAsync();
        }


        public async Task UpdateCustomer()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteCustomer(Guid customerId)
        {
            CustomerEntityModel existingCustomer = await _context.Client.FirstOrDefaultAsync(x => x.customerId == customerId);
            if (existingCustomer == null)
            {
                return false;
            }

            _context.Client.Remove(existingCustomer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

