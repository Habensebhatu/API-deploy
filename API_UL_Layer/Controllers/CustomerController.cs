using Business_Logic_Layer;
using Business_Logic_Layer.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace API_UL_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerBLL _CustomerBLL;

        public CustomerController()
        {
            _CustomerBLL = new CustomerBLL();
        }
        [HttpPost]
        public async Task<ActionResult<CustomerModel>> addCustomer([FromBody] CustomerModel customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            CustomerModel result = await _CustomerBLL.AddCustomer(customer);

            return result;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerModel>>> GetCustomers()
        {
            List<CustomerModel> customers = await _CustomerBLL.GetCustomers();
            return customers;
        }

        [HttpGet("{customerId:guid}")]
        public async Task<ActionResult<CustomerModel>> GetCustomerById(Guid customerId)
        {
            CustomerModel customer = await _CustomerBLL.GetCustomerById(customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }




        [HttpPut("{customerId:guid}")]
        public async Task<ActionResult<CustomerModel>> UpdateCustomer(Guid customerId, [FromBody] CustomerModel customer)
        {
            //if (publicIdentifier != customer.PublicIdentifier)
            //{
            //    return BadRequest();
            //}

            var result = await _CustomerBLL.UpdateCustomer(customerId, customer);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<CustomerModel>>> SearchCustomers([FromQuery] string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return BadRequest();
            }

            var customers = await _CustomerBLL.SearchCustomers(query);
            return customers;
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            bool result = await _CustomerBLL.DeleteCustomer(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
