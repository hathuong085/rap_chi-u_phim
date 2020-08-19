using Cimena.Domain.Responses.ChairOn;
using System.Threading.Tasks;

namespace Cimena.BAL.INTERFACE
{
    public interface IChairOnService
    {
        Task<CreateChairOnResult> CreateChairOn(ChairOn request);
        Task<DeleteChairOnResult> DeleteChairOn(ChairOn request);
    }
}

