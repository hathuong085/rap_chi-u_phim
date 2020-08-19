using Cimena.BAL.INTERFACE;
using Cimena.Domain.Responses.CategoryFilm;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimena.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryFilmController:ControllerBase
    {
        private readonly ICategoryFilmService categoryFilmService;

        public CategoryFilmController(ICategoryFilmService categoryFilmService)
        {
            this.categoryFilmService = categoryFilmService;
        }
        [HttpGet]
        [Route("/api/CategoryFilm/Gets")]
        public async Task<IEnumerable<CategoyryFilmResult>> GetCategories()
        {
            return await categoryFilmService.GetCategories();
        }
        [HttpGet]
        [Route("/api/CategoryFilm/GetbyCateId/{id}")]
        public async Task<CategoryFilm> GetCategoryById(int id)
        {
            return await categoryFilmService.GetCategory(id);
        }
    }
}
