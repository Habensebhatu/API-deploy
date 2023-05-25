using System;
namespace Business_Logic_Layer.ViewModel
{
    public class CustomerModel
    {
        public Guid customerId { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public int phone { get; set; }
        public string? info { get; set; }
    }

}

