using ViewModel;

namespace ServiceContract
{
    public interface IAppRoleContract
    {
        public Task<ResponseViewModel> getByIdAppRole(Guid id);
        public Task<ResponseViewModel> getAllAppRole();
        public Task<ResponseViewModel> addAppRole(AddAppRoleViewModel addAppRoleViewModel);
        public Task<ResponseViewModel> updateAppRole(UpdateAppRoleViewModel updateAppRoleViewModel);
        public Task<ResponseViewModel> deleteAppRole(DeleteAppRoleViewModel deleteAppRoleViewModel);
    }
}
