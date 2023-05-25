using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access_Layer.Context
{
    public class WorkActivitiesEntityModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
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

