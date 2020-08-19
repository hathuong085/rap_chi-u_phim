using Cimena.BAL.INTERFACE;
using Cimena.Domain.Requests.Customer;
using Cimena.Domain.Responses.Customer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimena.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpPost]
        [Route("/api/Customer/Create/")]
        public Task<CustomerResult> Create(CustomerRequests request)
        {
            return customerService.CreateCustomer(request);
        }
    }
}
