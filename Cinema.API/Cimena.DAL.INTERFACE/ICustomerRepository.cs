using Cimena.Domain.Requests.Customer;
using Cimena.Domain.Responses.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cimena.DAL.INTERFACE
{
    public interface ICustomerRepository
    {
        Task<CustomerResult> CreateCustomer(CustomerRequests request);
    }
}
