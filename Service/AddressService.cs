using RepositoryContract;
using ServiceContract;
using ViewModel;

namespace Service
{
   public class AddressService : IAddressContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public AddressService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseViewModel> getDefaultAddress(Guid addressId)
        {
            var getDefaultAddress = await _repositoryManager.addressRepository.getDefaultAddress(addressId);
            return getDefaultAddress;
        }

        public async Task<ResponseViewModel> getAddressList(Guid addressId)
        {
            var getAddressList = await _repositoryManager.addressRepository.getAddressList(addressId);
            return getAddressList;
        }

        public async Task<ResponseViewModel> addAddress(AddAddressViewModel addAddress)
        {
            var add = await _repositoryManager.addressRepository.addAddress(addAddress);
            return add;
        }

        public async Task<ResponseViewModel> updateAddress(UpdateAddressViewModel updateAddress)
        {
            var update = await _repositoryManager.addressRepository.updateAddress(updateAddress);
            return update;
        }

        public async Task<ResponseViewModel> deleteAddress(DeleteAddressViewModel deleteAddress)
        {
            var delete = await _repositoryManager.addressRepository.deleteAddress(deleteAddress);
            return delete;
        }
    }
}
