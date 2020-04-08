using System;
using TestXUnit.Business.Model;

namespace TestXUnit.Business.Services
{
    public interface ICustomerService : IDisposable
    {
        void Add(Customer customer);
    }
}