using System;
using Data_Access_Layer.Context;
using Data_Access_Layer.Data;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer
{
    public class WorkActivitiesDAL
    {
        private readonly MyDbContext _context;
        public WorkActivitiesDAL()
        {
            _context = new MyDbContext();
        }

        public async Task<WorkActivitiesEntityModel> AddWorkActivities(WorkActivitiesEntityModel WorkActivities)
        {
            _context.WorkActivities.Add(WorkActivities);
            await _context.SaveChangesAsync();
            return WorkActivities;

        }
        public async Task<List<WorkActivitiesEntityModel>> GetWorkActivities(Guid RapairId)
        {
            return await _context.WorkActivities.Where(x => x.repairId == RapairId).ToListAsync();
        }

        public async Task<WorkActivitiesEntityModel> GetWorkActivitiesById(Guid workId)
        {
            return await _context.WorkActivities.FirstOrDefaultAsync(x => x.workId == workId);

        }

        public async Task UpdateWorkActivities()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteWorkActivities(WorkActivitiesEntityModel existingWorkActivities)
        {

            if (existingWorkActivities == null)
            {
                return false;
            }

            _context.WorkActivities.Remove(existingWorkActivities);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

