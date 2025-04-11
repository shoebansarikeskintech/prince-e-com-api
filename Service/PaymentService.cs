using RepositoryContract;
using ServiceContract;
using ViewModel;

namespace Service
{
   public class PaymentService : IPaymentContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public PaymentService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<ResponseViewModel> getCheckPaymentStatus(Guid orderId)
        {
            var getCheckPaymentStatus = await _repositoryManager.paymentRepository.getCheckPaymentStatus(orderId);
            return getCheckPaymentStatus;
        }

        public async Task<ResponseViewModel> getPaymentList()
        {
            var getPaymentList = await _repositoryManager.paymentRepository.getPaymentList();
            return getPaymentList;
        }
        public async Task<ResponseViewModel> getPaymentMode()
        {
            var getPaymentMode = await _repositoryManager.paymentRepository.getPaymentMode();
            return getPaymentMode;
        }
        public async Task<ResponseViewModel> addPaymentMode(AddPaymentModeViewModel addPaymentModeViewModel)
        {
            return await _repositoryManager.paymentRepository.addPaymentMode(addPaymentModeViewModel);
        }

        public async Task<ResponseViewModel> updatePaymentMode(UpdatePaymentModeViewModel updatePaymentModeViewModel)
        {
            return await _repositoryManager.paymentRepository.updatePaymentMode(updatePaymentModeViewModel);
        }

        public async Task<ResponseViewModel> deletePaymentMode(DeletePaymentModeViewModel deletePaymentModeViewModel)
        {
            return await _repositoryManager.paymentRepository.deletePaymentMode(deletePaymentModeViewModel);
        }
    }
}
