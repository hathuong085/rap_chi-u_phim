using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cimena.Domain.Responses.ComboFood;

namespace Cimena.DAL.INTERFACE
{
    public interface IComboFoodRepository
    {
        Task<IEnumerable<ComboFood>> Gets();
        Task<IEnumerable<ComboFoodAll>> GetAll();
        Task<ComboFood> Get(int cfid);
        Task<SaveComboFoodResult> SaveComboFood(ComboFood request);
        Task<DeleteCFResult> DeleteComboFood(int cfid);
        Task<DeleteCFResult> RestoreComboFood(int cfid);
    }
}
