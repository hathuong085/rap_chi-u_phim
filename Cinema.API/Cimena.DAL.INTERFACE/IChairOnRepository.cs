using Cimena.Domain.Responses.ChairOn;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cimena.DAL.INTERFACE
{
    public interface IChairOnRepository
    {
        Task<CreateChairOnResult> CreateChairOn(ChairOn request);
        Task<DeleteChairOnResult> DeleteChairOn(ChairOn request);
    }
}
