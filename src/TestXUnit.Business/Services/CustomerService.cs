using TestXUnit.Business.Model;
using TestXUnit.Business.Repositories;

namespace TestXUnit.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Add(Customer customer)
        {
            if (!customer.IsValid())
                return;

            _customerRepository.Add(customer);
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }
    }
}
