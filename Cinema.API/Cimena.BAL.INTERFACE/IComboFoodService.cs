using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cimena.Domain.Responses.ComboFood;

namespace Cimena.BAL.INTERFACE
{
    public interface IComboFoodService
    {
        Task<IEnumerable<ComboFood>> Gets();
        Task<ComboFood> Get(int cfid);
        Task<SaveComboFoodResult> SaveComboFood(ComboFood request);
        Task<DeleteCFResult> DeleteComboFood(int cfid);
        Task<DeleteCFResult> RestoreComboFood(int cfid);
        Task<IEnumerable<ComboFoodAll>> GetAll();
    }
}
