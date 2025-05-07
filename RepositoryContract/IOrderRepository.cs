

using ViewModel;

namespace RepositoryContract
{
   public interface IOrderRepository
    {
        public Task<ResponseViewModel> getAllOrder(Guid userId);
        public Task<ResponseViewModel> getAllOrderlist();
        public Task<ResponseViewModel> getAllPendingOrder();
        public Task<ResponseViewModel> getAllProcessingOrder(Guid adminUserId);
        public Task<ResponseViewModel> getAllCompletedOrder();
        public Task<ResponseViewModel> getAllCancelOrder();
        public Task<ResponseViewModel> addOrderWithDetails(AddOrderWithDetailsViewModel AddOrderWithDetails);
        public Task<ResponseViewModel> getAllOrderByOrderId(string orderId);
        public Task<ResponseViewModel> getAllOrderByNameorEmail(String userNameorEmail);
        public Task<ResponseViewModel> updateOrderStatus(UpdateStausViewModel aUpdateStausDetails);
        public Task<ResponseViewModel> getOrderWithItems(string orderIdOrOrderNo);
        public Task<ResponseViewModel> updateShipped(updateShippedViewModel updateShipped);

        public Task<ResponseViewModel> updateDelivery(updateDelCanRetCompViewModel updateDelCanRetCompViewModel);
        public Task<ResponseViewModel> cancelOrder(updateDelCanRetCompViewModel updateDelCanRetCompViewModel);
        public Task<ResponseViewModel> returnOrder(updateDelCanRetCompViewModel updateDelCanRetCompViewModel);
        public Task<ResponseViewModel> returnOrderCompleted(updateDelCanRetCompViewModel updateDelCanRetCompViewModel);
        public Task<ResponseViewModel> getOrdersBySearch(string searchValue);
        public Task<ResponseViewModel> getAllReturnOrderlist();
        public Task<ResponseViewModel> getAllShippingOrderlist();


    }
}
