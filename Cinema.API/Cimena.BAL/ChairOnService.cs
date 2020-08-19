using Cimena.BAL.INTERFACE;
using Cimena.DAL.INTERFACE;
using Cimena.Domain.Responses.ChairOn;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cimena.BAL
{
    public class ChairOnService : IChairOnService
    {
        private readonly IChairOnRepository chairOnRepository;
       

        public ChairOnService(IChairOnRepository chairOnRepository)
        {
            this.chairOnRepository = chairOnRepository;
         
        }

        public async Task<CreateChairOnResult> CreateChairOn(ChairOn request)
        {
            return await chairOnRepository.CreateChairOn(request);
        }

        public async Task<DeleteChairOnResult> DeleteChairOn(ChairOn request)
        {
            return await chairOnRepository.DeleteChairOn(request);
        }
    }
}
