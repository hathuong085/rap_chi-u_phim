using Cimena.Domain.Responses.CategoryFilm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cimena.BAL.INTERFACE
{
    public interface ICategoryFilmService
    {
        Task<IEnumerable<CategoyryFilmResult>> GetCategories();
        Task<CategoryFilm> GetCategory(int cateId);
    }
}
