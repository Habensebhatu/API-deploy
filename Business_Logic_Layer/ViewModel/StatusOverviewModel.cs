using System;
namespace Business_Logic_Layer.ViewModel
{
	public class StatusOverviewModel
	{
        public Guid statusId { get; set; }
        public string? status { get; set; }
        public string? watchMaker { get; set; }
        public string remark { get; set; }
        public string creationDate { get; set; }
        public Guid repairId { get; set; }
    }
}

