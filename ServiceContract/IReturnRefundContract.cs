

using ViewModel;

namespace ServiceContract
{
   public interface IReturnRefundContract
    {
        public Task<ResponseViewModel> getAllRefundOrder(Guid adminuserId);
        public Task<ResponseViewModel> updateRefundOrderStatus(UpdateRefundOrderStatusViewModel updateRefundOrderStatus);
    }
}
