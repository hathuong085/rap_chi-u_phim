using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Cimena.DAL.INTERFACE;
using Cimena.Domain.Responses.Order;
using Dapper;
namespace Cimena.DAL
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public async Task<DeleteOrderResult> DeleteOrder(int orderid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@OrderId", orderid);
            return await SqlMapper.QueryFirstOrDefaultAsync<DeleteOrderResult>(cnn: conn,
                             param: parameters,
                            sql: "DeleteOrder",
                            commandType: CommandType.StoredProcedure);
        }



        public async Task<Order> Get(int orderid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@OrderId", orderid);
            return (await SqlMapper.QueryFirstOrDefaultAsync<Order>(cnn: conn,
                             param: parameters,
                            sql: "GetOrderByid",
                            commandType: CommandType.StoredProcedure));
        }

        public async Task<IEnumerable<Order>> Gets()
        {
            return await SqlMapper.QueryAsync<Order>(conn, "GetsOrder", CommandType.StoredProcedure);
        }

        public async Task<SaveOrderResult> SaveOrder(Order request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@OrderId", request.OrderId);
                parameters.Add("@ComboFoodId", request.ComboFoodId);
                parameters.Add("@Count", request.Count);
                parameters.Add("@BookFilmId", request.BookFilmId);
                //parameters.Add("@TotalPrice", request.TotalPrice);
                return (await SqlMapper.QueryFirstOrDefaultAsync<SaveOrderResult>(cnn: conn,
                                            sql: "InsertEditOrder",
                                            param: parameters,
                                            commandType: CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                return new SaveOrderResult()
                {
                    OrderId = 0,
                    Message = "Something went wrong, please try again"
                };
            }
        }
    }
}
