using RepositoryContract;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service
{
    public class IngredientServices : IIngredientContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public IngredientServices(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseViewModel> getAllIngredientMethod()
        {
            var getIngredientMethod = await _repositoryManager.ingredientRepository.getAllIngredientMethod();

            //var getAllShippingMethod = await _repositoryManager.getAllIngredientMethod.getAllShippingMethod();
            return getIngredientMethod;
        }

        public async Task<ResponseViewModel> addIngredientMethod(AddIngredientViewModel addIngredientMethod)
        {
            var add = await _repositoryManager.ingredientRepository.addIngredientMethod(addIngredientMethod);
            return add;
        }

        public async Task<ResponseViewModel> updateIngredientMethod(UpdateIngredientViewModel updateIngredientMethod)
        {
            var update = await _repositoryManager.ingredientRepository.updateIngredientMethod(updateIngredientMethod);
            return update;
        }

        public async Task<ResponseViewModel> deleteIngredientMethod(DeleteIngredientViewModel deleteIngredientMethod)
        {
            var delete = await _repositoryManager.ingredientRepository.deleteIngredientMethod(deleteIngredientMethod);
            return delete;
        }


    }
}
