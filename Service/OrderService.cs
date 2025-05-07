using RepositoryContract;
using ServiceContract;
using ViewModel;

namespace Service
{
   public class OrderService : IOrderContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public OrderService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<ResponseViewModel> getAllOrder(Guid userId)
        {
            var getAllOrder = await _repositoryManager.orderRepository.getAllOrder(userId);
            return getAllOrder;
        }

        public async Task<ResponseViewModel> getAllOrderlist()
        {
            var getAllOrderlist = await _repositoryManager.orderRepository.getAllOrderlist();
            return getAllOrderlist;
        }
        public async Task<ResponseViewModel> getAllPendingOrder()
        {
            var getAllOrder = await _repositoryManager.orderRepository.getAllPendingOrder();
            return getAllOrder;
        }

        public async Task<ResponseViewModel> getAllProcessingOrder(Guid adminUserId)
        {
            var getAllOrder = await _repositoryManager.orderRepository.getAllProcessingOrder(adminUserId);
            return getAllOrder;
        }
        public async Task<ResponseViewModel> getAllCompletedOrder()
        {
            var getAllOrder = await _repositoryManager.orderRepository.getAllCompletedOrder();
            return getAllOrder;
        }
        public async Task<ResponseViewModel> getAllCancelOrder()
        {
            var getAllOrder = await _repositoryManager.orderRepository.getAllCancelOrder();
            return getAllOrder;
        }
        public async Task<ResponseViewModel> getAllReturnOrderlist()
        {
            var getAllReturnOrderlist = await _repositoryManager.orderRepository.getAllReturnOrderlist();
            return getAllReturnOrderlist;
        }

        public async Task<ResponseViewModel> getAllShippingOrderlist()
        {
            var getAllShippingOrderlist = await _repositoryManager.orderRepository.getAllShippingOrderlist();
            return getAllShippingOrderlist;
        }
        public async Task<ResponseViewModel> addOrderWithDetails(AddOrderWithDetailsViewModel addOrderWithDetails)
        {
            var add = await _repositoryManager.orderRepository.addOrderWithDetails(addOrderWithDetails);
            return add;
        }

        public async Task<ResponseViewModel> getAllOrderByOrderId(string orderId)
        {
            var GetAllOrderByOrderId = await _repositoryManager.orderRepository.getAllOrderByOrderId(orderId);
            return GetAllOrderByOrderId;
        }
        public async Task<ResponseViewModel> getAllOrderByNameorEmail(String userNameorEmail)
        {
            var getAllOrderByNameorEmail = await _repositoryManager.orderRepository.getAllOrderByNameorEmail(userNameorEmail);
            return getAllOrderByNameorEmail;
        }

        public async Task<ResponseViewModel> updateOrderStatus(UpdateStausViewModel aUpdateStausDetails)
        {
            var add = await _repositoryManager.orderRepository.updateOrderStatus(aUpdateStausDetails);
            return add;
        }

        public async Task<ResponseViewModel> getOrderWithItems(string orderIdOrOrderNo)
        {
            var getOrderWithItems = await _repositoryManager.orderRepository.getOrderWithItems(orderIdOrOrderNo);
            return getOrderWithItems;
        }

        public async Task<ResponseViewModel> updateShipped(updateShippedViewModel updateShipped)
        {
            var update = await _repositoryManager.orderRepository.updateShipped(updateShipped);
            return update;
        }

        public async Task<ResponseViewModel> updateDelivery(updateDelCanRetCompViewModel updateDelCanRetCompViewModel)
        {
            var update = await _repositoryManager.orderRepository.updateDelivery(updateDelCanRetCompViewModel);
            return update;
        }

        public async Task<ResponseViewModel> cancelOrder(updateDelCanRetCompViewModel updateDelCanRetCompViewModel)
        {
            var update = await _repositoryManager.orderRepository.cancelOrder(updateDelCanRetCompViewModel);
            return update;
        }

        public async Task<ResponseViewModel> returnOrder(updateDelCanRetCompViewModel updateDelCanRetCompViewModel)
        {
            var update = await _repositoryManager.orderRepository.returnOrder(updateDelCanRetCompViewModel);
            return update;
        }

        public async Task<ResponseViewModel> returnOrderCompleted(updateDelCanRetCompViewModel updateDelCanRetCompViewModel)
        {
            var update = await _repositoryManager.orderRepository.returnOrderCompleted(updateDelCanRetCompViewModel);
            return update;
        }

        public async Task<ResponseViewModel> getOrdersBySearch(string searchValue)
        {
            var getOrdersBySearch = await _repositoryManager.orderRepository.getOrdersBySearch(searchValue);
            return getOrdersBySearch;
        }
    }
}
