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

        public async Task<ResponseViewModel> getOrdersBySearch(string searchValue)
        {
            var getOrdersBySearch = await _repositoryManager.orderRepository.getOrdersBySearch(searchValue);
            return getOrdersBySearch;
        }

        public async Task<ResponseViewModel> getAllReturnOrderCompleted()
        {
            var getAllReturnOrderCompleted = await _repositoryManager.orderRepository.getAllReturnOrderCompleted();
            return getAllReturnOrderCompleted;
        }
        public async Task<ResponseViewModel> getAllReturnOrderAccepted()
        {
            var getAllReturnOrderAccepted = await _repositoryManager.orderRepository.getAllReturnOrderAccepted();
            return getAllReturnOrderAccepted;
        }

        public async Task<ResponseViewModel> getAllCancelOrderAccepted()
        {
            var getAllCancelOrderAccepted = await _repositoryManager.orderRepository.getAllCancelOrderAccepted();
            return getAllCancelOrderAccepted;
        }

        public async Task<ResponseViewModel> getAllCancelOrderAcceptedCompleted()
        {
            var getAllCancelOrderAcceptedCompleted = await _repositoryManager.orderRepository.getAllCancelOrderAcceptedCompleted();
            return getAllCancelOrderAcceptedCompleted;
        }
    }
}
