using RepositoryContract;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service
{
    public class RoleMenuService : IRoleMenuContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public RoleMenuService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseViewModel> getByIdRoleMenu(Guid roleMenuId)
        {
            var getByIdRoleMenu = await _repositoryManager.roleMenuRepository.getByIdRoleMenu(roleMenuId);
            return getByIdRoleMenu;
        }

        public async Task<ResponseViewModel> getAllRoleMenu()
        {
            var getAllRoleMenu = await _repositoryManager.roleMenuRepository.getAllRoleMenu();
            return getAllRoleMenu;
        }

        public async Task<ResponseViewModel> addRoleMenu(AddRoleMenuViewModel addRoleMenuViewModel)
        {
            var addRoleMenu = await _repositoryManager.roleMenuRepository.addRoleMenu(addRoleMenuViewModel);
            return addRoleMenu;
        }

        public async Task<ResponseViewModel> updateRoleMenu(UpdateRoleMenuViewModel updateRoleMenuViewModel)
        {
            var updateRoleMenu = await _repositoryManager.roleMenuRepository.updateRoleMenu(updateRoleMenuViewModel);
            return updateRoleMenu;
        }

        public async Task<ResponseViewModel> deleteRoleMenu(DeleteRoleMenuViewModel deleteRoleMenuViewModel)
        {
            var deleteRoleMenu = await _repositoryManager.roleMenuRepository.deleteRoleMenu(deleteRoleMenuViewModel);
            return deleteRoleMenu;
        }
    }
}
