using RepositoryContract;
using ServiceContract;
using ViewModel;

namespace Service
{
    public class AppRoleService : IAppRoleContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public AppRoleService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseViewModel> getByIdAppRole(Guid appRoleId)
        {
            var getByIdAppRole = await _repositoryManager.appRoleRepository.getByIdAppRole(appRoleId);
            return getByIdAppRole;
        }

        public async Task<ResponseViewModel> getAllAppRole()
        {
            var getAllAppRole = await _repositoryManager.appRoleRepository.getAllAppRole();
            return getAllAppRole;
        }

        public async Task<ResponseViewModel> addAppRole(AddAppRoleViewModel addAppRoleViewModel)
        {
            var addAppRole = await _repositoryManager.appRoleRepository.addAppRole(addAppRoleViewModel);
            return addAppRole;
        }

        public async Task<ResponseViewModel> updateAppRole(UpdateAppRoleViewModel updateAppRoleViewModel)
        {
            var updateAppRole = await _repositoryManager.appRoleRepository.updateAppRole(updateAppRoleViewModel);
            return updateAppRole;
        }

        public async Task<ResponseViewModel> deleteAppRole(DeleteAppRoleViewModel deleteAppRoleViewModel)
        {
            var deleteAppRole = await _repositoryManager.appRoleRepository.deleteAppRole(deleteAppRoleViewModel);
            return deleteAppRole;
        }
    }
}
