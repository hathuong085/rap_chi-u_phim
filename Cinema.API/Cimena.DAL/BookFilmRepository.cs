using Cimena.DAL.INTERFACE;
using Cimena.Domain.Requests.BookFilm;
using Cimena.Domain.Responses.BookFilm;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Cimena.DAL
{
    public class BookFilmRepository : BaseRepository, IBookFilmRepository
    {
        public async Task<BookFilmResult> CreateBookFilm(BookFilmRequests request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CusId", request.CusId);
            parameters.Add("@ShowingId", request.ShowingId);
            parameters.Add("@ListChair", request.ListChair);
            parameters.Add("@CountTicket", request.CountTicket); 
            parameters.Add("@PriceTiket", request.PriceTiket);
            parameters.Add("@TotalPrice", request.TotalPrice);
            return (await SqlMapper.QueryFirstOrDefaultAsync<BookFilmResult>(cnn: conn,
                             param: parameters,
                            sql: "sp_CreateBookFilm",
                            commandType: CommandType.StoredProcedure));
        }
    }
}
