using Common;
using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using ViewModel;
using static Model.ModelType;

namespace Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly DapperContext _dapperContext;
        public MenuRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;
        public async Task<ResponseViewModel> getByIdMenu(Guid id)
        {
            var procedureName = Constant.spGetByIdMenu;
            var parameters = new DynamicParameters();
            parameters.Add("@menuId", id, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Menu>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getbyIdMenu = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getbyIdMenu;
            }
        }
        public async Task<ResponseViewModel> getAllMenu(Int64 type)
        {
            var procedureName = Constant.spGetAllMenu;
            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@type", type);
                    var result = await connection.QueryAsync<Menu>(procedureName,param, null, commandType: CommandType.StoredProcedure);
                    var getAllMenu = new ResponseViewModel
                    {
                        statusCode = result.Any() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound,
                        message = result.Any() ? "Data Found" : "Data Not Found",
                        data = result
                    };
                    return getAllMenu;
                }
            }
            catch (Exception ex)
            {
                return new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = $"Error: {ex.Message}",
                    data = null
                };
            }
        }

        public async Task<ResponseViewModel> getMenuByUserRole(string userName)
        {
            var procedureName = Constant.spGetMenuByUserRole;
            var parameters = new DynamicParameters();
            parameters.Add("@userName", userName, DbType.String);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<MenuByUserRole>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getbyIdMenu = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getbyIdMenu;
            }
        }
        public async Task<ResponseViewModel> addMenu(AddMenuViewModel addMenuViewModel)
        {
            var procedureName = Constant.spAddMenu;
            var parameters = new DynamicParameters();
            parameters.Add("@menuName", addMenuViewModel.menuName, DbType.String);
            parameters.Add("@displayOrder", addMenuViewModel.displayOrder, DbType.Int32);
            parameters.Add("@createdBy", addMenuViewModel.createdBy, DbType.Guid);
            parameters.Add("@menuIcon", addMenuViewModel.menuIcon, DbType.String);

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (result.statusCode == 1)
                {
                    result.statusCode = (int)HttpStatusCode.OK;
                    result.message = result.message;
                }
                else if (result.statusCode == 0)
                {
                    result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                    result.message = result.message;
                }
                else
                {
                    result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                    result.message = result.message;
                }
                return result;
            }
        }
        public async Task<ResponseViewModel> updateMenu(UpdateMenuViewModel updateMenuViewModel)
        {
            var procedureName = Constant.spUpdateMenu;

            var parameters = new DynamicParameters();
            parameters.Add("@menuId", updateMenuViewModel.menuId, DbType.Guid);
            parameters.Add("@menuName", updateMenuViewModel.menuName, DbType.String);
            parameters.Add("@pageName", updateMenuViewModel.pageName, DbType.String);
            parameters.Add("@controllerName", updateMenuViewModel.controllerName, DbType.String);
            parameters.Add("@actionName", updateMenuViewModel.actionName, DbType.String);
            parameters.Add("@displayOrder", updateMenuViewModel.displayOrder, DbType.Int32);
            parameters.Add("@updatedBy", updateMenuViewModel.updatedBy, DbType.Guid);
            parameters.Add("@menuIcon", updateMenuViewModel.menuIcon, DbType.String);
            parameters.Add("@active", updateMenuViewModel.active, DbType.Boolean);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (result.statusCode == 1)
                {
                    result.statusCode = (int)HttpStatusCode.OK;
                    result.message = result.message;
                }
                else if (result.statusCode == 0)
                {
                    result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                    result.message = result.message;
                }
                else
                {
                    result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                    result.message = result.message;
                }
                return result;
            }
        }
        public async Task<ResponseViewModel> deleteMenu(DeleteMenuViewModel deleteMenuViewModel)
        {
            var procedureName = Constant.spDeleteMenu;
            var parameters = new DynamicParameters();
            parameters.Add("@menuId", deleteMenuViewModel.menuId, DbType.Guid);
            parameters.Add("@updatedBy", deleteMenuViewModel.updatedBy, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (result.statusCode == 1)
                {
                    result.statusCode = (int)HttpStatusCode.OK;
                    result.message = result.message;
                }
                else if (result.statusCode == 0)
                {
                    result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                    result.message = result.message;
                }
                else
                {
                    result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                    result.message = result.message;
                }
                return result;
            }
        }
        public async Task<ResponseViewModel> getAllMenuOfSubMenu()
        {
            var procedureMenu = Constant.spGetAllMenu;
            var procedureSubMenu = Constant.spGetAllSubMenu;

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var resultMenu = await connection.QueryAsync<Menu>(procedureMenu, commandType: CommandType.StoredProcedure);
                    var resultSubMenu = await connection.QueryAsync<GetAllSubMenu>(procedureSubMenu, commandType: CommandType.StoredProcedure);

                    var subMenuLookup = resultSubMenu.ToLookup(sub => sub.menuId);

                    var menuList = resultMenu.Select(menu => new
                    {
                        menuId = menu.menuId,
                        menuName = menu.menuName,
                        subMenu = subMenuLookup[menu.menuId].Select(sub => new
                        {
                            subMenuId = sub.subMenuId,
                            menuId = sub.menuId,
                            subMenuName = sub.subMenuName,
                            subMenuPageName = sub.subMenuPageName,
                            menuName = sub.menuName,
                            pageName = sub.pageName
                        }).ToList()
                    }).ToList();

                    return new ResponseViewModel
                    {
                        statusCode = menuList.Any() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound,
                        message = menuList.Any() ? "Data Found" : "Data Not Found",
                        data = menuList
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = $"Error occurred: {ex.Message}",
                    data = null
                };
            }
        }

    }
}
