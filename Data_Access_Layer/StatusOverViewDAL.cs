using System;
using Data_Access_Layer.Context;
using Data_Access_Layer.Data;
using Data_Access_Layer.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer
{
    public class StatusOverviewDAL
    {
        private readonly MyDbContext _context;
        public StatusOverviewDAL()
        {
            _context = new MyDbContext();
        }

        public async Task<StatusOverviewEntityModel> AddStatusOverview(StatusOverviewEntityModel statusOverview)
        {
            _context.StatusOverview.Add(statusOverview);
            await _context.SaveChangesAsync();
            return statusOverview;

        }

        public async Task<List<StatusOverviewEntityModel>> GetStatusOverviewById(Guid repairId)
        {
            return await _context.StatusOverview.Where(x => x.repairId == repairId).ToListAsync();

        }

        public async Task<bool> DeleteStatusOverviewById(Guid statusId)
        {
            StatusOverviewEntityModel existingCustomer = await _context.StatusOverview.FirstOrDefaultAsync(x => x.statusId == statusId);
            if (existingCustomer == null)
            {
                return false;
            }

            _context.StatusOverview.Remove(existingCustomer);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}

