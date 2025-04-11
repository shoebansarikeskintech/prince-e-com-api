
using RepositoryContract;
using ServiceContract;
using ViewModel;

namespace Service
{
    public class ShippingService : IShippingContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public ShippingService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseViewModel> getByIdShipping(Guid shippingId)
        {
            var getByIdShipping = await _repositoryManager.shippingRepository.getByIdShipping(shippingId);
            return getByIdShipping;
        }

        public async Task<ResponseViewModel> getAllShipping()
        {
            var getAllShipping = await _repositoryManager.shippingRepository.getAllShipping();
            return getAllShipping;
        }

        public async Task<ResponseViewModel> addShipping(AddShippingViewModel addShipping)
        {
            var add = await _repositoryManager.shippingRepository.addShipping(addShipping);
            return add;
        }

        public async Task<ResponseViewModel> updateShipping(UpdateShippingViewModel updateShipping)
        {
            var update = await _repositoryManager.shippingRepository.updateShipping(updateShipping);
            return update;
        }

        public async Task<ResponseViewModel> deleteShipping(DeleteShippingViewModel deleteShipping)
        {
            var delete = await _repositoryManager.shippingRepository.deleteShipping(deleteShipping);
            return delete;
        }
    }
}

