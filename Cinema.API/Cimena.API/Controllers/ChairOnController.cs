using Cimena.BAL.INTERFACE;
using Cimena.Domain.Responses.ChairOn;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cimena.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChairOnController : ControllerBase
    {
        private readonly IChairOnService chairOnService;
        public ChairOnController(IChairOnService chairOnService)
        {
            this.chairOnService = chairOnService;
        }

        [HttpPost]
        [Route("/api/chairOn/create")]
        public async Task<CreateChairOnResult> CreateChairOn(ChairOn request)
        {
            return await chairOnService.CreateChairOn(request);
        }

        [HttpPost]
        [Route("/api/chairOn/delete")]
        public async Task<DeleteChairOnResult> DeleteChairOn(ChairOn request)
        {
            return await chairOnService.DeleteChairOn(request);
           
        }

    }
}
