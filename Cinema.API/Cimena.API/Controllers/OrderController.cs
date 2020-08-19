using System.Collections.Generic;
using System.Threading.Tasks;
using Cimena.BAL;
using Cimena.BAL.INTERFACE;
using Cimena.Domain.Responses.Film;
using Cimena.Domain.Responses.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cimena.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService orderService;

        public OrderController(ILogger<OrderController> logger,
                                    IOrderService orderService)
        {
            _logger = logger;
            this.orderService = orderService;
        }

        /// <summary>
        /// Get all Order in DB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/order/gets")]
        public async Task<IEnumerable<Order>> Gets()
        {
            return await orderService.Gets();
        }

        /// <summary>
        /// Get Order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/order/get/{id}")]
        public async Task<Order> Get(int id)
        {
            return await orderService.Get(id);
        }

        [HttpPost]
        [Route("/api/order/save")]
        public async Task<SaveOrderResult> SaveOrder(Order request)
        {
            return await orderService.SaveOrder(request);
        }

        [HttpDelete]
        [Route("/api/order/delete/{id}")]
        public async Task<DeleteOrderResult> DeleteOrder(int id)
        {
            return await orderService.DeleteOrder(id);
        }
    }
}
