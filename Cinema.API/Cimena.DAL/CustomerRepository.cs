using Cimena.DAL.INTERFACE;
using Cimena.Domain.Requests.Customer;
using Cimena.Domain.Responses.Customer;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Cimena.DAL
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public async Task<CustomerResult> CreateCustomer(CustomerRequests request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", request.Name);
            parameters.Add("@Mail", request.Mail);
            parameters.Add("@PhoneNumber", request.PhoneNumber);
            return (await SqlMapper.QueryFirstOrDefaultAsync<CustomerResult>(cnn: conn,
                             param: parameters,
                            sql: "sp_CreateCustomer",
                            commandType: CommandType.StoredProcedure));
        }
    }
}
