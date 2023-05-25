using Business_Logic_Layer.ViewModel;
using Data_Access_Layer;
using Data_Access_Layer.Context;

namespace Business_Logic_Layer
{
    public class CustomerBLL
    {
        private readonly CustomerDAL _CustomerDAL;
        public CustomerBLL()
        {
            _CustomerDAL = new CustomerDAL();
        }
        public async Task<CustomerModel> AddCustomer(CustomerModel customer)
        {
            CustomerEntityModel customerFormaat = new CustomerEntityModel()
            {
                customerId = Guid.NewGuid(),
                name = customer.name,
                email = customer.email,
                info = customer.info,
                phone = customer.phone
            };
            await _CustomerDAL.AddCustomer(customerFormaat);
            return customer;
        }
        public async Task<List<CustomerModel>> GetCustomers()
        {
            List<CustomerEntityModel> customers = await _CustomerDAL.GetCustomers();
            List<CustomerModel> customerModels = customers.Select(c => new CustomerModel()
            {
                customerId = c.customerId,
                name = c.name!,
                email = c.email!,
                info = c.info!,
                phone = c.phone
            }).ToList();

            return customerModels;
        }

        public async Task<CustomerModel> GetCustomerById(Guid customerId)
        {
            CustomerEntityModel customer = await _CustomerDAL.GetCustomerById(customerId);
            if (customer == null)
            {
                return null;
            }

            CustomerModel customerModel = new CustomerModel()
            {
                customerId = customer.customerId,
                name = customer.name!,
                email = customer.email!,
                info = customer.info!,
                phone = customer.phone
            };

            return customerModel;
        }

        public async Task<List<CustomerModel>> SearchCustomers(string query)
        {
            var customers = await _CustomerDAL.SearchCustomers(query);
            return customers.Select(c => new CustomerModel
            {
                customerId = c.customerId,
                name = c.name,
                email = c.email,
                info = c.info,
                phone = c.phone
            }).ToList();
        }


        public async Task<CustomerModel> UpdateCustomer(Guid customerId, CustomerModel customer)
        {

            var existingCustomer = await _CustomerDAL.GetCustomerById(customerId);

            if (existingCustomer == null)
            {
                return null;
            }

            existingCustomer.name = customer.name;
            existingCustomer.email = customer.email;
            existingCustomer.info = customer.info;
            existingCustomer.phone = customer.phone;

            try
            {
                await _CustomerDAL.UpdateCustomer();
            }
            catch (Exception ex)
            {
                return null;
            }
            return new CustomerModel
            {
                customerId = existingCustomer.customerId,
                name = existingCustomer.name,
                email = existingCustomer.email,
                info = existingCustomer.info,
                phone = existingCustomer.phone
            };
        }

        public async Task<bool> DeleteCustomer(Guid PublicIdentifier)
        {
            bool result = await _CustomerDAL.DeleteCustomer(PublicIdentifier);
            return result;
        }

    }
}

