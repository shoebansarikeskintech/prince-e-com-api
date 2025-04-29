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
    public class MenuService : IMenuContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public MenuService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseViewModel> getByIdMenu(Guid menuId)
        {
            var getByIdMenu = await _repositoryManager.menuRepository.getByIdMenu(menuId);
            return getByIdMenu;
        }

        public async Task<ResponseViewModel> getAllMenu(Int64 type)
        {
            var getAllMenu = await _repositoryManager.menuRepository.getAllMenu(type);
            return getAllMenu;
        }

        public async Task<ResponseViewModel> addMenu(AddMenuViewModel addMenuViewModel)
        {
            var addMenu = await _repositoryManager.menuRepository.addMenu(addMenuViewModel);
            return addMenu;
        }

        public async Task<ResponseViewModel> updateMenu(UpdateMenuViewModel updateMenuViewModel)
        {
            var updateMenu = await _repositoryManager.menuRepository.updateMenu(updateMenuViewModel);
            return updateMenu;
        }

        public async Task<ResponseViewModel> deleteMenu(DeleteMenuViewModel deleteMenuViewModel)
        {
            var deleteMenu = await _repositoryManager.menuRepository.deleteMenu(deleteMenuViewModel);
            return deleteMenu;
        }
        public async Task<ResponseViewModel> getMenuByUserRole(string userName)
        {
            return await _repositoryManager.menuRepository.getMenuByUserRole(userName); ;
        }

        public async Task<ResponseViewModel> getAllMenuOfSubMenu()
        {
            var getAllMenuOfSubMenu = await _repositoryManager.menuRepository.getAllMenuOfSubMenu();
            return getAllMenuOfSubMenu;
        }
        
    }
}
