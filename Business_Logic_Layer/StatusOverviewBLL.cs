using System;
using Business_Logic_Layer.ViewModel;
using Data_Access_Layer;
using Data_Access_Layer.Context;

namespace Business_Logic_Layer
{
    public class StatusOverviewBLL
    {
        private readonly StatusOverviewDAL _statusOverviewDAL;
        public StatusOverviewBLL()
        {
            _statusOverviewDAL = new StatusOverviewDAL();
        }

        public async Task<StatusOverviewModel> AddStatusOverView(StatusOverviewModel statusOverview)
        {
            StatusOverviewEntityModel formaatStatusOverview = new StatusOverviewEntityModel()
            {
                statusId = Guid.NewGuid(),
                status = statusOverview.status,
                creationDate = statusOverview.creationDate,
                watchMaker = statusOverview.watchMaker,
                remark = statusOverview.remark,
                repairId = statusOverview.repairId,
            };
            await _statusOverviewDAL.AddStatusOverview(formaatStatusOverview);
            return statusOverview;
        }
        public async Task<IEnumerable<StatusOverviewModel>> GetStatusOverviewById(Guid RepairId)
        {
            var statusOverview = await _statusOverviewDAL.GetStatusOverviewById(RepairId);

            return statusOverview.Select(s => new StatusOverviewModel
            {
                statusId = s.statusId,
                status = s.status,
                creationDate = s.creationDate,
                watchMaker = s.watchMaker,
                remark = s.remark,
                repairId = s.repairId,
            });

        }

        public async Task<bool> DeleteStatusOverviewById(Guid id)
        {
            bool result = await _statusOverviewDAL.DeleteStatusOverviewById(id);
            return result;
        }


    }
}

