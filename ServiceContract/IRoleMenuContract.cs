using ViewModel;

namespace ServiceContract
{
    public interface IRoleMenuContract
    {
        public Task<ResponseViewModel> getByIdRoleMenu(Guid id);
        public Task<ResponseViewModel> getAllRoleMenu();
        public Task<ResponseViewModel> addRoleMenu(AddRoleMenuViewModel addRoleMenuViewModel);
        public Task<ResponseViewModel> updateRoleMenu(UpdateRoleMenuViewModel updateRoleMenuViewModel);
        public Task<ResponseViewModel> deleteRoleMenu(DeleteRoleMenuViewModel deleteRoleMenuViewModel);
    }
}
