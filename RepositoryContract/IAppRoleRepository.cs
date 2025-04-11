using ViewModel;

namespace RepositoryContract
{
    public interface IAppRoleRepository
    {
        public Task<ResponseViewModel> getByIdAppRole(Guid id);
        public Task<ResponseViewModel> getAllAppRole();
        public Task<ResponseViewModel> addAppRole(AddAppRoleViewModel addAppRoleViewModel);
        public Task<ResponseViewModel> updateAppRole(UpdateAppRoleViewModel updateAppRoleViewModel);
        public Task<ResponseViewModel> deleteAppRole(DeleteAppRoleViewModel deleteAppRoleViewModel);
    }
}
