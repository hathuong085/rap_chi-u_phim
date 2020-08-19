using Cimena.DAL.INTERFACE;
using Cimena.Domain.Responses.CategoryFilm;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Cimena.DAL
{
    public class CategoryFilmRepository :BaseRepository,ICategoryFilmRepository
    {
        public async Task<IEnumerable<CategoyryFilmResult>> GetCategories()
        {
            return await SqlMapper.QueryAsync<CategoyryFilmResult>(conn, "sp_GetCategories", CommandType.StoredProcedure);
        }

        public async Task<CategoryFilm> GetCategory(int cateId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CateId", cateId);
            return (await SqlMapper.QueryFirstOrDefaultAsync<CategoryFilm>(cnn: conn,
                             param: parameters,
                            sql: "sp_GetsCategoryFilmByCateFilmId",
                            commandType: CommandType.StoredProcedure));
        }
    }
}
