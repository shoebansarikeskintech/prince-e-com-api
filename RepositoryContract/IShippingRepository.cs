
using ViewModel;

namespace RepositoryContract
{
   public interface IShippingRepository
    {
        public Task<ResponseViewModel> getByIdShipping(Guid shippingId);
        public Task<ResponseViewModel> getAllShipping();
        public Task<ResponseViewModel> addShipping(AddShippingViewModel addShipping);
        public Task<ResponseViewModel> updateShipping(UpdateShippingViewModel updateShipping);
        public Task<ResponseViewModel> deleteShipping(DeleteShippingViewModel deleteShipping);
    }
}
