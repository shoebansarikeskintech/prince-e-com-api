

using ViewModel;

namespace RepositoryContract
{
   public interface IReturnRefundRepository
    {
        public Task<ResponseViewModel> getAllRefundOrder(Guid adminUserId);
        public Task<ResponseViewModel> updateRefundOrderStatus(UpdateRefundOrderStatusViewModel updateRefundOrderStatus);
    }
}
