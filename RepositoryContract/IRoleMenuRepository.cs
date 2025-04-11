
using ViewModel;

namespace RepositoryContract
{
    public interface IRoleMenuRepository
    {
        public Task<ResponseViewModel> getByIdRoleMenu(Guid id);
        public Task<ResponseViewModel> getAllRoleMenu();
        public Task<ResponseViewModel> addRoleMenu(AddRoleMenuViewModel addRoleMenuViewModel);
        public Task<ResponseViewModel> updateRoleMenu(UpdateRoleMenuViewModel updateRoleMenuViewModel);
        public Task<ResponseViewModel> deleteRoleMenu(DeleteRoleMenuViewModel deleteRoleMenuViewModel);
    }
}
