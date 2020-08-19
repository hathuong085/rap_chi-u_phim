using Cimena.BAL.INTERFACE;
using Cimena.DAL.INTERFACE;
using Cimena.Domain.Responses.CategoryFilm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cimena.BAL
{
   public class CategoryFilmService : ICategoryFilmService
    {
        private readonly ICategoryFilmRepository categoryFilmRepository;

        public CategoryFilmService(ICategoryFilmRepository categoryFilmRepository)
        {
            this.categoryFilmRepository = categoryFilmRepository;
        }

        public Task<IEnumerable<CategoyryFilmResult>> GetCategories()
        {
            return categoryFilmRepository.GetCategories();
        }

        public Task<CategoryFilm> GetCategory(int cateId)
        {
            return categoryFilmRepository.GetCategory(cateId);
        }
    }
}
