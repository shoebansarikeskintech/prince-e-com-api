using ViewModel;

namespace ServiceContract
{
   public interface IAddressContract
    {
        public Task<ResponseViewModel> getDefaultAddress(Guid userId);
        public Task<ResponseViewModel> getAddressList(Guid userId);
        public Task<ResponseViewModel> addAddress(AddAddressViewModel addBrand);
        public Task<ResponseViewModel> updateAddress(UpdateAddressViewModel updateBrand);
        public Task<ResponseViewModel> deleteAddress(DeleteAddressViewModel deleteBrand);
    }
}
