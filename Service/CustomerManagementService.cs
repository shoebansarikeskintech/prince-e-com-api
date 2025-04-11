using RepositoryContract;
using ServiceContract;
using ViewModel;

namespace Service
{
    public class CustomerManagementService : ICustomerManagementContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public CustomerManagementService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

  
        public async Task<ResponseViewModel> getAllCustomer()
        {
            var getAllCustomer = await _repositoryManager.customerManagementRepository.getAllCustomer();
            return getAllCustomer;
        }

        public async Task<ResponseViewModel> getAllOrderByUser(string username)
        {
            var getAllCustomer = await _repositoryManager.customerManagementRepository.getAllOrderByUser(username);
            return getAllCustomer;
        }

        public async Task<ResponseViewModel> getAppUserProfileDetails(Guid userId)
        {
            var getAllCustomer = await _repositoryManager.customerManagementRepository.getAppUserProfileDetails(userId);
            return getAllCustomer;
        }

        public async Task<ResponseViewModel> appUserUpdateProfile(UpdateProfileViewModel updateBrand)
        {
            var update = await _repositoryManager.customerManagementRepository.appUserUpdateProfile(updateBrand);
            return update;
        }

        public async Task<ResponseViewModel> appUserUpdatePassword(UpdatePasswordViewModel updateBrand)
        {
            var update = await _repositoryManager.customerManagementRepository.appUserUpdatePassword(updateBrand);
            return update;
        }
    }
}
