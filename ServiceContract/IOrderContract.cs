
using ViewModel;

namespace ServiceContract
{
   public interface IOrderContract
    {
        public Task<ResponseViewModel> getAllOrder(Guid adminUserId);
        public Task<ResponseViewModel> getAllPendingOrder(Guid adminUserId);
        public Task<ResponseViewModel> getAllProcessingOrder(Guid adminUserId);
        public Task<ResponseViewModel> getAllCompletedOrder(Guid adminUserId);
        public Task<ResponseViewModel> getAllCancelOrder(Guid adminUserId);

        public Task<ResponseViewModel> addOrderWithDetails(AddOrderWithDetailsViewModel addOrderWithDetails);

    }
}
