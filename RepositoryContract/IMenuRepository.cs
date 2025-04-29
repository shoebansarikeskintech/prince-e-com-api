using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace RepositoryContract
{
    public interface IMenuRepository
    {
        public Task<ResponseViewModel> getByIdMenu(Guid id);
        public Task<ResponseViewModel> getAllMenu(Int64 type);
        public Task<ResponseViewModel> addMenu(AddMenuViewModel addMenuViewModel);
        public Task<ResponseViewModel> updateMenu(UpdateMenuViewModel updateMenuViewModel);
        public Task<ResponseViewModel> deleteMenu(DeleteMenuViewModel deleteMenuViewModel);
        public Task<ResponseViewModel> getMenuByUserRole(string userName);
        public Task<ResponseViewModel> getAllMenuOfSubMenu();

        

    }
}
