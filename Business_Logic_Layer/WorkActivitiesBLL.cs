using System;
using Business_Logic_Layer.ViewModel;
using Data_Access_Layer;
using Data_Access_Layer.Context;
using Microsoft.EntityFrameworkCore;

namespace Business_Logic_Layer
{
    public class WorkActivitiesBLL
    {
        private readonly WorkActivitiesDAL _WorkActivitiesDAL;
        public WorkActivitiesBLL()
        {
            _WorkActivitiesDAL = new WorkActivitiesDAL();
        }

        public async Task<WorkActivitiesModel> AddWorkActivities(WorkActivitiesModel WorkActivities)
        {
            WorkActivitiesEntityModel formaatWorkActivities = new WorkActivitiesEntityModel()
            {
                workId = Guid.NewGuid(),
                performedWork = WorkActivities.performedWork,
                priceExclVat = WorkActivities.priceExclVat,
                priceInclVat = WorkActivities.priceInclVat,
                creationDate = WorkActivities.creationDate,
                repairId = WorkActivities.repairId,

            };
            await _WorkActivitiesDAL.AddWorkActivities(formaatWorkActivities);

            return WorkActivities;
        }

        public async Task<IEnumerable<WorkActivitiesModel>> GetWorkActivities(Guid RepairId)
        {
            var workActivities = await _WorkActivitiesDAL.GetWorkActivities(RepairId);
            return workActivities.Select(x => new WorkActivitiesModel
            {
                workId  = x.workId,
                performedWork = x.performedWork,
                priceExclVat = x.priceExclVat,
                priceInclVat = x.priceInclVat,
                creationDate = x.creationDate,
                repairId = x.repairId,
            });
        }

        public async Task<WorkActivitiesModel> GetWorkActivitiesByID(Guid publicIdentifier)
        {
            var workActivities = await _WorkActivitiesDAL.GetWorkActivitiesById(publicIdentifier);
            if (workActivities == null)
            {
                return null;
            }

            var workActivitiesModel = new WorkActivitiesModel
            {
                workId  = workActivities.workId,
                performedWork = workActivities.performedWork,
                priceExclVat = workActivities.priceExclVat,
                priceInclVat = workActivities.priceInclVat,
                creationDate = workActivities.creationDate,
                repairId = workActivities.repairId,
            };

            return workActivitiesModel;
        }

        public async Task<WorkActivitiesModel> UpdateWorkActivities(Guid publicIdentifier, WorkActivitiesModel WorkActivities)
        {
            var existingWorkActivities = await _WorkActivitiesDAL.GetWorkActivitiesById(publicIdentifier);
            if (existingWorkActivities == null)
            {
                return null;
            }

            existingWorkActivities.performedWork = WorkActivities.performedWork;
            existingWorkActivities.priceExclVat = WorkActivities.priceExclVat;
            existingWorkActivities.priceInclVat = WorkActivities.priceInclVat;
            existingWorkActivities.creationDate = WorkActivities.creationDate;
            existingWorkActivities.repairId = WorkActivities.repairId;

            await _WorkActivitiesDAL.UpdateWorkActivities();

            return WorkActivities;

        }

        public async Task<bool> DeleteWorkActivities(Guid publicIdentifier)
        {
            var existingWorkActivities = await _WorkActivitiesDAL.GetWorkActivitiesById(publicIdentifier);
            if (existingWorkActivities == null)
            {
                return false;
            }

            await _WorkActivitiesDAL.DeleteWorkActivities(existingWorkActivities);

            return true;
        }
    }
}

