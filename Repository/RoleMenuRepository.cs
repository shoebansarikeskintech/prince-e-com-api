using Common;
using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using ViewModel;
using static Model.ModelType;

namespace Repository
{
    public class RoleMenuRepository : IRoleMenuRepository
    {
        private readonly DapperContext _dapperContext;
        public RoleMenuRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;
        public async Task<ResponseViewModel> getByIdRoleMenu(Guid roleMenuId)
        {
            var procedureName = Constant.spGetByIdRoleMenu;
            var parameters = new DynamicParameters();
            parameters.Add("@roleMenuId", roleMenuId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<RoleMenu>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getbyIdRoleMenu = new ResponseViewModel
                {
                    statusCode = result.Count() == 1 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 1 ? "Data Not Found" : "Data Found",
                    data = result
                };

                return getbyIdRoleMenu;
            }
        }
        public async Task<ResponseViewModel> getAllRoleMenu()
        {
            var procedureName = Constant.spGetAllRoleMenu;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<RoleMenu>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllRoleMenu = new ResponseViewModel
                {
                    statusCode = result.Count() == 1 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 1 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllRoleMenu;
            }
        }
        public async Task<ResponseViewModel> addRoleMenu(AddRoleMenuViewModel addRoleMenuViewModel)
        {
            var procedureName = Constant.spAddRoleMenu;
            var parameters = new DynamicParameters();
            parameters.Add("@appRoleId", addRoleMenuViewModel.appRoleId, DbType.Guid);
            parameters.Add("@menuId", addRoleMenuViewModel.menuId, DbType.Guid);
            parameters.Add("@subMenuId", addRoleMenuViewModel.subMenuId, DbType.Guid);
            parameters.Add("@createdBy", addRoleMenuViewModel.createdBy, DbType.Guid);

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
        public async Task<ResponseViewModel> updateRoleMenu(UpdateRoleMenuViewModel updateRoleMenuViewModel)
        {
            var procedureName = Constant.spUpdateRoleMenu;

            var parameters = new DynamicParameters();
            parameters.Add("@roleMenuId", updateRoleMenuViewModel.roleMenuId, DbType.Guid);
            parameters.Add("@appRoleId", updateRoleMenuViewModel.appRoleId, DbType.Guid);
            parameters.Add("@menuId", updateRoleMenuViewModel.menuId, DbType.Guid);
            parameters.Add("@subMenuId", updateRoleMenuViewModel.subMenuId, DbType.Guid);
            parameters.Add("@updatedBy", updateRoleMenuViewModel.updatedBy, DbType.Guid);
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
        public async Task<ResponseViewModel> deleteRoleMenu(DeleteRoleMenuViewModel deleteRoleMenuViewModel)
        {
            var procedureName = Constant.spDeleteRoleMenu;
            var parameters = new DynamicParameters();
            parameters.Add("@roleMenuId", deleteRoleMenuViewModel.roleMenuId, DbType.Guid);
            parameters.Add("@appRoleId", deleteRoleMenuViewModel.appRoleId, DbType.Guid);
            parameters.Add("@menuId", deleteRoleMenuViewModel.menuId, DbType.Guid);
            parameters.Add("@subMenuId", deleteRoleMenuViewModel.subMenuId, DbType.Guid);
            parameters.Add("@updatedBy", deleteRoleMenuViewModel.updatedBy, DbType.Guid);

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
    }
}
