using RepositoryContract;
using ServiceContract;
using ViewModel;

namespace Service
{
   public class ReturnRefundService : IReturnRefundContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public ReturnRefundService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<ResponseViewModel> getAllRefundOrder(Guid adminUserId)
        {
            var getAllRefundOrder = await _repositoryManager.returnRefundRepository.getAllRefundOrder(adminUserId);
            return getAllRefundOrder;
        }

        public async Task<ResponseViewModel> updateRefundOrderStatus(UpdateRefundOrderStatusViewModel updateRefundOrderStatus)
        {
            var update = await _repositoryManager.returnRefundRepository.updateRefundOrderStatus(updateRefundOrderStatus);
            return update;
        }
    }
}
