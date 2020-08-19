using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cimena.BAL.INTERFACE;
using Cimena.DAL.INTERFACE;
using Cimena.Domain.Responses.Order;
namespace Cimena.BAL
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<DeleteOrderResult> DeleteOrder(int orderid)
        {
            return await orderRepository.DeleteOrder(orderid);
        }

        public async Task<Order> Get(int orderid)
        {
            return await orderRepository.Get(orderid);
        }

        public async Task<IEnumerable<Order>> Gets()
        {
            return await orderRepository.Gets();
        }

        public async Task<SaveOrderResult> SaveOrder(Order request)
        {
            return await orderRepository.SaveOrder(request);
        }
    }
}
