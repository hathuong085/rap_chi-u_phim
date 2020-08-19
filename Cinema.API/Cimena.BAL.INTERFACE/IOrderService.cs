using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cimena.Domain.Responses.Order;
namespace Cimena.BAL.INTERFACE
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> Gets();
        Task<Order> Get(int orderid);
        Task<SaveOrderResult> SaveOrder(Order request);
        Task<DeleteOrderResult> DeleteOrder(int orderid);
    }
}
