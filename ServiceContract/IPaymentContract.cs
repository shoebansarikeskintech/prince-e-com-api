

using ViewModel;

namespace ServiceContract
{
   public interface IPaymentContract
    {
        public Task<ResponseViewModel> getCheckPaymentStatus(Guid orderId);
        public Task<ResponseViewModel> getPaymentList();
        public Task<ResponseViewModel> getPaymentMode();
        public Task<ResponseViewModel> addPaymentMode(AddPaymentModeViewModel addPaymentModeViewModel);
        public Task<ResponseViewModel> updatePaymentMode(UpdatePaymentModeViewModel updatePaymentModeViewModel);
        public Task<ResponseViewModel> deletePaymentMode(DeletePaymentModeViewModel deletePaymentModeViewModel);
    }
}
