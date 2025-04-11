using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace RepositoryContract
{
    public interface IShippingMethodRepository
    {
        public Task<ResponseViewModel> getAllShippingMethod();
        public Task<ResponseViewModel> addShippingMethod(AddShippingMethodViewModel addShippingMethod);
        public Task<ResponseViewModel> updateShippingMethod(UpdateShippingMethodViewModel updateShippingMethod);
        public Task<ResponseViewModel> deleteShippingMethod(DeleteShippingMethodViewModel deleteShippingMethod);

    }
}
