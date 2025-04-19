

using ViewModel;

namespace RepositoryContract
{
   public interface IOrderRepository
    {
        public Task<ResponseViewModel> getAllOrder(Guid userId);
        public Task<ResponseViewModel> getAllOrderlist();
        public Task<ResponseViewModel> getAllPendingOrder(Guid adminUserId);
        public Task<ResponseViewModel> getAllProcessingOrder(Guid adminUserId);
        public Task<ResponseViewModel> getAllCompletedOrder(Guid adminUserId);
        public Task<ResponseViewModel> getAllCancelOrder(Guid adminUserId);
        public Task<ResponseViewModel> addOrderWithDetails(AddOrderWithDetailsViewModel AddOrderWithDetails);
        public Task<ResponseViewModel> getAllOrderByOrderId(string orderId);
        public Task<ResponseViewModel> getAllOrderByNameorEmail(String userNameorEmail);
        public Task<ResponseViewModel> updateOrderStatus(UpdateStausViewModel aUpdateStausDetails);
        public Task<ResponseViewModel> getOrderWithItems(string orderIdOrOrderNo);
    }
}
