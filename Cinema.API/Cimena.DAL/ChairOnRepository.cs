using Cimena.DAL.INTERFACE;
using Cimena.Domain.Responses.ChairOn;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Cimena.DAL
{
   public class ChairOnRepository : BaseRepository, IChairOnRepository
    {
        public async Task<CreateChairOnResult> CreateChairOn(ChairOn request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@SeatId", request.SeatId);
            parameters.Add("@ShowingId", request.ShowingId);
            return (await SqlMapper.QueryFirstOrDefaultAsync<CreateChairOnResult>(cnn: conn,
                             param: parameters,
                            sql: "CreateChairOn",
                            commandType: CommandType.StoredProcedure));
        }

        public async Task<DeleteChairOnResult> DeleteChairOn(ChairOn request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@SeatId",request.SeatId);
            parameters.Add("@ShowingId", request.ShowingId);
            return await SqlMapper.QueryFirstOrDefaultAsync<DeleteChairOnResult>(cnn: conn,
                             param: parameters,
                            sql: "DeleteChairOn",
                            commandType: CommandType.StoredProcedure);
        }
    }
}
