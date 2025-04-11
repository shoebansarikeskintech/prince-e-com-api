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
        public async Task<ResponseViewModel> getAllOrder(Guid adminUserId)
        {
            var getAllOrder = await _repositoryManager.orderRepository.getAllOrder(adminUserId);
            return getAllOrder;
        }
        public async Task<ResponseViewModel> getAllPendingOrder(Guid adminUserId)
        {
            var getAllOrder = await _repositoryManager.orderRepository.getAllPendingOrder(adminUserId);
            return getAllOrder;
        }

        public async Task<ResponseViewModel> getAllProcessingOrder(Guid adminUserId)
        {
            var getAllOrder = await _repositoryManager.orderRepository.getAllProcessingOrder(adminUserId);
            return getAllOrder;
        }
        public async Task<ResponseViewModel> getAllCompletedOrder(Guid adminUserId)
        {
            var getAllOrder = await _repositoryManager.orderRepository.getAllCompletedOrder(adminUserId);
            return getAllOrder;
        }
        public async Task<ResponseViewModel> getAllCancelOrder(Guid adminUserId)
        {
            var getAllOrder = await _repositoryManager.orderRepository.getAllCancelOrder(adminUserId);
            return getAllOrder;
        }

        public async Task<ResponseViewModel> addOrderWithDetails(AddOrderWithDetailsViewModel addOrderWithDetails)
        {
            var add = await _repositoryManager.orderRepository.addOrderWithDetails(addOrderWithDetails);
            return add;
        }

        public async Task<ResponseViewModel> getAllOrderByOrderId(Guid orderId)
        {
            var GetAllOrderByOrderId = await _repositoryManager.orderRepository.getAllOrderByOrderId(orderId);
            return GetAllOrderByOrderId;
        }
        public async Task<ResponseViewModel> getAllOrderByName(String userName)
        {
            var GetAllOrderByName = await _repositoryManager.orderRepository.getAllOrderByName(userName);
            return GetAllOrderByName;
        }
    }
}
