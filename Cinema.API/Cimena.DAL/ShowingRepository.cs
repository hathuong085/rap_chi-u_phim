using Cimena.DAL.INTERFACE;
using Cimena.Domain.Requests.Film;
using Cimena.Domain.Requests.ShowFilm;
using Cimena.Domain.Responses.Showing;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Cimena.DAL
{
    public class ShowingRepository : BaseRepository,IShowingRepository
    {
        public async Task<IEnumerable<Dayshow>> DayShowOfFilm(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@FilmId", id);
            return await SqlMapper.QueryAsync<Dayshow>(cnn: conn,sql: "sp_ScreeningDateOfFilm", param: parameters,commandType: CommandType.StoredProcedure);
        }

        public async Task<MessageSuccess> DeleteShowingByTime()
        {
            return await SqlMapper.QueryFirstOrDefaultAsync<MessageSuccess>(conn, "sp_deleteshowedsByTimes", CommandType.StoredProcedure);
        }

        public async Task<DescriptionShowing> DescriptionShowing(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@showingId", id);
            return await SqlMapper.QueryFirstOrDefaultAsync<DescriptionShowing>(cnn: conn, sql: "sp_DescriptionOfShowing", param: parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AllDesShwing>> GetAllShowing()
        {
            return await SqlMapper.QueryAsync<AllDesShwing>(cnn: conn, sql: "sp_GetAllShowing", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TimeShow>> ScreeningFilmOfDate(ShowingOfFilmOfDayRequests request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@FilmId", request.FilmId);
            parameters.Add("@Day",request.DayShow);
            return await SqlMapper.QueryAsync<TimeShow>(cnn: conn, sql: "sp_ShowingsOfFilmOf1Day", param: parameters, commandType: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<DayShow>> SearchDayshowByPeriod(SeacrhDayRequests requests)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ToDate", requests.ToDate);
            parameters.Add("@FromDate", requests.FromDate);
            return (await SqlMapper.QueryAsync<DayShow>(cnn: conn,
                             param: parameters,
                            sql: "sp_SearchDayshowByPeriod",
                            commandType: CommandType.StoredProcedure));
        }

        public async Task<IEnumerable<TimeResult>> TimeEmptybyRoomDay(TimeRequests requests)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@RoomId",requests.RoomId);
            parameters.Add("@Day", requests.DayShow);
            return await SqlMapper.QueryAsync<TimeResult>(cnn: conn, sql: "sp_TimeEmptyByRoomDay", param: parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Seat>> SeatsOfShowing(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@showingId", id);
            return await SqlMapper.QueryAsync<Seat>(cnn: conn, sql: "sp_SeatsOfShowing", param: parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DayShow>> Top7DatesShow()
        {
            return await SqlMapper.QueryAsync<DayShow>(cnn: conn, sql: "sp_Top7DatesShow", commandType: CommandType.StoredProcedure);
        }

        public async Task<CreateShowingResult> CreateShowing(CreateShowingRequests requests)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FilmId", requests.FilmId);
                parameters.Add("@TimeId", requests.TimeId);
                parameters.Add("@RoomId", requests.RoomId);
                parameters.Add("@Dayshow", requests.DayShow);
                return (await SqlMapper.QueryFirstOrDefaultAsync<CreateShowingResult>(cnn: conn,
                                 param: parameters,
                                sql: "sp_CreateShowing",
                                commandType: CommandType.StoredProcedure));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
