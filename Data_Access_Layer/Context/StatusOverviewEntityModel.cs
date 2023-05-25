using System;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Context
{
    public class StatusOverviewEntityModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid statusId { get; set; }
        public string? status { get; set; }
        public string? watchMaker { get; set; }
        public string remark { get; set; }
        public string creationDate { get; set; }
        public Guid repairId { get; set; }
    }
}

