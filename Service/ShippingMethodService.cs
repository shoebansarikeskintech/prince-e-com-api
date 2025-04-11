using RepositoryContract;
using ServiceContract;
using ViewModel;

namespace Service
{
    public class ShippingMethodService: IShippingMethodContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public ShippingMethodService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseViewModel> getAllShippingMethod()
        {
            var getAllShippingMethod = await _repositoryManager.shippingMethodRepository.getAllShippingMethod();
            return getAllShippingMethod;
        }

        public async Task<ResponseViewModel> addShippingMethod(AddShippingMethodViewModel addShippingMethod)
        {
            var add = await _repositoryManager.shippingMethodRepository.addShippingMethod(addShippingMethod);
            return add;
        }

        public async Task<ResponseViewModel> updateShippingMethod(UpdateShippingMethodViewModel updateShippingMethod)
        {
            var update = await _repositoryManager.shippingMethodRepository.updateShippingMethod(updateShippingMethod);
            return update;
        }

        public async Task<ResponseViewModel> deleteShippingMethod(DeleteShippingMethodViewModel deleteShippingMethod)
        {
            var delete = await _repositoryManager.shippingMethodRepository.deleteShippingMethod(deleteShippingMethod);
            return delete;
        }
    }
}
