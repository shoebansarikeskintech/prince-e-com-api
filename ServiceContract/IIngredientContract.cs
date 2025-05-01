using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ServiceContract
{
    public interface IIngredientContract
    {
        public Task<ResponseViewModel> getAllIngredientMethod();
        public Task<ResponseViewModel> getAllIngredientActiveMethod();
        public Task<ResponseViewModel> addIngredientMethod(AddIngredientViewModel addIngredientMethod);
        public Task<ResponseViewModel> updateIngredientMethod(UpdateIngredientViewModel updateIngredientMethod);
        public Task<ResponseViewModel> deleteIngredientMethod(DeleteIngredientViewModel deleteIngredientMethod);

    }
}
