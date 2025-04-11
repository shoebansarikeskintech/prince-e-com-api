using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ServiceContract
{
    public interface IMenuContract
    {
        public Task<ResponseViewModel> getByIdMenu(Guid id);
        public Task<ResponseViewModel> getAllMenu();
        public Task<ResponseViewModel> addMenu(AddMenuViewModel addMenuViewModel);
        public Task<ResponseViewModel> updateMenu(UpdateMenuViewModel updateMenuViewModel);
        public Task<ResponseViewModel> deleteMenu(DeleteMenuViewModel deleteMenuViewModel);
        public Task<ResponseViewModel> getMenuByUserRole(string userName);
        public Task<ResponseViewModel> getAllMenuOfSubMenu();

    }
}
