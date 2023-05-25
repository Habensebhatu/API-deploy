using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Logic_Layer.ViewModel
{
	public class WorkActivitiesModel
	{
        public Guid workId { get; set; }
        public string performedWork { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal priceExclVat { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal priceInclVat { get; set; }
        public string creationDate { get; set; }
        public Guid repairId { get; set; }
    }
}

