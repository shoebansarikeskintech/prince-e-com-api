
using ViewModel;

namespace ServiceContract
{
   public interface IOrderContract
    {
        public Task<ResponseViewModel> getAllOrder(Guid userId);
        public Task<ResponseViewModel> getAllOrderlist();
        public Task<ResponseViewModel> getAllPendingOrder();
        public Task<ResponseViewModel> getAllProcessingOrder(Guid adminUserId);
        public Task<ResponseViewModel> getAllCompletedOrder();
        public Task<ResponseViewModel> getAllCancelOrder();

        public Task<ResponseViewModel> addOrderWithDetails(AddOrderWithDetailsViewModel addOrderWithDetails);

        public Task<ResponseViewModel> updateOrderStatus(UpdateStausViewModel aUpdateStausDetails);

        public Task<ResponseViewModel> getOrderWithItems(string orderIdOrOrderNo);

        public Task<ResponseViewModel> getOrdersBySearch(string searchValue);

        public Task<ResponseViewModel> getAllReturnOrderlist();
        public Task<ResponseViewModel> getAllShippingOrderlist();
        public Task<ResponseViewModel> getAllReturnOrderCompleted();
        public Task<ResponseViewModel> getAllReturnOrderAccepted();
        public Task<ResponseViewModel> getAllCancelOrderAccepted();
        public Task<ResponseViewModel> getAllCancelOrderAcceptedCompleted();

        public Task<ResponseViewModel> getAllArrivedToOrderlist();

        public Task<ResponseViewModel> getTrackOrder(string OrderNo);

    }
}
