using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cimena.BAL.INTERFACE;
using Cimena.DAL.INTERFACE;
using Cimena.Domain.Responses.ComboFood;

namespace Cimena.BAL
{
    public class ComboFoodService : IComboFoodService
    {
        private readonly IComboFoodRepository comboFoodRepository;

        public ComboFoodService(IComboFoodRepository comboFoodRepository)
        {
            this.comboFoodRepository = comboFoodRepository;
        }

        public async Task<DeleteCFResult> DeleteComboFood(int cfid)
        {
            return await comboFoodRepository.DeleteComboFood(cfid);
        }

        public async Task<DeleteCFResult> RestoreComboFood(int cfid)
        {
            return await comboFoodRepository.RestoreComboFood(cfid);
        }

        public async Task<ComboFood> Get(int cfid)
        {
            return await comboFoodRepository.Get(cfid);
        }

        public Task<IEnumerable<ComboFoodAll>> GetAll()
        {
            return comboFoodRepository.GetAll();
        }

        public async Task<IEnumerable<ComboFood>> Gets()
        {
            return await comboFoodRepository.Gets();
        }

        public async Task<SaveComboFoodResult> SaveComboFood(ComboFood request)
        {
            return await comboFoodRepository.SaveComboFood(request);
        }
    }
}
