using Common;
using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using ViewModel;
using static Model.ModelType;

namespace Repository
{
    public class AppRoleRepository : IAppRoleRepository
    {
        private readonly DapperContext _dapperContext;
        public AppRoleRepository(DapperContext dapperContext) => _dapperContext = dapperContext;
      
        public async Task<ResponseViewModel> getByIdAppRole(Guid id)
        {
            var procedureName = Constant.spGetByIdAppRole;
            var parameters = new DynamicParameters();
            parameters.Add("@appRoleId", id, DbType.Guid);

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<AppRole>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getbyIdAppRole = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Get App User Data Found",
                    data = result
                };
                return getbyIdAppRole;
            }
        }

        public async Task<ResponseViewModel> getAllAppRole()
        {
            var procedureName = Constant.spGetAllAppRole;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<AppRole>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllAppRole = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Get All App User Data Found",
                    data = result
                };
                return getAllAppRole;
            }
        }

        public async Task<ResponseViewModel> addAppRole(AddAppRoleViewModel addAppRole)
        {
            var procedureName = Constant.spAddAppRole;

            addAppRole.createdBy = Guid.NewGuid();
            var parameters = new DynamicParameters();
            parameters.Add("@roleName", addAppRole.roleName, DbType.String);
            parameters.Add("@createdBy", addAppRole.createdBy, DbType.Guid);

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

        public async Task<ResponseViewModel> updateAppRole(UpdateAppRoleViewModel updateAppRoleViewModel)
        {
            var procedureName = Constant.spUpdateAppRole;

            var parameters = new DynamicParameters();
            parameters.Add("@appRoleId", updateAppRoleViewModel.appRoleId, DbType.Guid);
            parameters.Add("@roleName", updateAppRoleViewModel.roleName, DbType.String);
            parameters.Add("@updatedBy", updateAppRoleViewModel.updatedBy, DbType.Guid);

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

        public async Task<ResponseViewModel> deleteAppRole(DeleteAppRoleViewModel deleteAppRoleViewModel)
        {
            var procedureName = Constant.spDeleteAppRole;

            var parameters = new DynamicParameters();
            parameters.Add("@appRoleId", deleteAppRoleViewModel.appRoleId, DbType.Guid);
            parameters.Add("@updatedBy", deleteAppRoleViewModel.updatedBy, DbType.Guid);
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
