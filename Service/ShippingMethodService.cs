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
        public async Task<ResponseViewModel> getAllPinCodeShippingMethod()
        {
            var getAllPinCodeshipping = await _repositoryManager.shippingMethodRepository.getAllPinCodeshippingMethod();
            return getAllPinCodeshipping;
        }

        public async Task<ResponseViewModel> addPinCodeShippingMethod(AddPinCodeShippingViewModel addPinCodeshippingMethod)
        {
            var add = await _repositoryManager.shippingMethodRepository.addPinCodeshippingMethod(addPinCodeshippingMethod);
            return add;
        }

        public async Task<ResponseViewModel> updatePinCodeShippingMethod(UpdatePinCodeShippingViewModel updatePinCodeshippingMethod)
        {
            var update = await _repositoryManager.shippingMethodRepository.updatePinCodeShippingMethod(updatePinCodeshippingMethod);
            return update;
        }

        public async Task<ResponseViewModel> deletePinCodeShippingMethod(DeletePinCodeShippingViewModel deletePinCodeShippingMethod)
        {
            var delete = await _repositoryManager.shippingMethodRepository.deletePinCodeShippingMethod(deletePinCodeShippingMethod);
            return delete;
        }
    }
}
