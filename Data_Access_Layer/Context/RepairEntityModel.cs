using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Data_Access_Layer.Context
{
    public class RepairEntityModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid _id { get; set; }

        [Required]
        [MaxLength(128)]
        public string name { get; set; }

        [Required]
        [MaxLength(128)]
        public string kenmerk { get; set; }

        [Required]
        public string gender { get; set; }

        [Required]
        [MaxLength(128)]
        public string wachtMakers { get; set; }

        [Required]
        [MaxLength(128)]
        public string merk { get; set; }

        [Required]
        [MaxLength(128)]
        public string aard { get; set; }

        [Required]
        [MaxLength(128)]
        public string customerId { get; set; }

        [Required]
        [MaxLength(128)]
        public string calibernummer { get; set; }

        [Required]
        [MaxLength(128)]
        public string kastnummer { get; set; }

        [Required]
        [MaxLength(128)]
        public string serienummer { get; set; }

        public string mechanism { get; set; }

        public string material { get; set; }

        public string typeBand { get; set; }

        public string status { get; set; }
    }
}


