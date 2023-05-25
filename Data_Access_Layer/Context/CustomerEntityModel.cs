using System.ComponentModel.DataAnnotations;
namespace Data_Access_Layer.Context
{
    public class CustomerEntityModel
    {
        [Key]
        public int Id { get; set; }
        public Guid customerId { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public int phone { get; set; }
        public string? info { get; set; }
    }
}

