using System;
using Data_Access_Layer.Context;
using Data_Access_Layer.Data;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer
{
    public class RepairDAL
    {
        private readonly MyDbContext _context;

        public RepairDAL()
        {
            _context = new MyDbContext();
        }

        public async Task<RepairEntityModel> CreateProduct(RepairEntityModel product)
        {
            _context.Repair.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<RepairEntityModel>> GetProducts()
        {
            return await _context.Repair.ToListAsync();
        }

        public async Task<RepairEntityModel> GetProductById(Guid _id)
        {
            return await _context.Repair.FirstOrDefaultAsync(x => x._id == _id);

        }

        public async Task UpdateProduct()
        {

            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateStatus(Guid _id, string status)
        {
            var repair = await _context.Repair.FirstOrDefaultAsync(x => x._id == _id);
            if (repair == null)
            {
                return false;
            }
            repair.status = status;

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<RepairEntityModel> DeleteProduct(Guid _id)
        {
            var product = await _context.Repair.FirstOrDefaultAsync(x => x._id == _id);

            if (product == null)
            {
                return null;
            }

            _context.Repair.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}

