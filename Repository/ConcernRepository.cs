using Dapper;
using RepositoryContract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Model.ModelType;
using ViewModel;
using static ViewModel.ConcernViewModel;
using Common;

namespace Repository
{
    public class ConcernRepository : IConcernReposotory
    {
        private readonly DapperContext _dapperContext;
        public ConcernRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;    
     public async Task<ResponseViewModel> getAllConcernMethod()
        {
            var procedureName = Constant.spGetAllConcern;
            var parameters = new DynamicParameters();

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<ConcernMethod>(
                        procedureName,
                        null,
                        commandType: CommandType.StoredProcedure
                    );

                    var IngredientMethodList = new ResponseViewModel
                    {
                        statusCode = result.Any() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound,
                        message = result.Any() ? "Concernt Data Found" : "Data Not Found",
                        data = result
                    };

                    return IngredientMethodList;
                }
            }
            catch (Exception ex)
            {
                return new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = $"An error occurred: {ex.Message}",
                    data = null
                };
            }
        }

        public async Task<ResponseViewModel> addConcernMethod(AddConcernViewModel addConcernMethod)
        {
            var procedureName = Constant.spAddConcern;
            var parameters = new DynamicParameters();
            parameters.Add("@name", addConcernMethod.name, DbType.String);
            parameters.Add("@description", addConcernMethod.description, DbType.String);
            parameters.Add("@createdBy", addConcernMethod.createdBy, DbType.Guid);

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


        public async Task<ResponseViewModel> updateConcernMethod(UpdateConcernViewModel updateConcernMethod)
        {
            var procedureName = Constant.spUpdateConcern;
            var parameters = new DynamicParameters();
            parameters.Add("@ConcernId", updateConcernMethod.ConcernId, DbType.Guid);
            parameters.Add("@name", updateConcernMethod.name, DbType.String);
            parameters.Add("@description", updateConcernMethod.description, DbType.String);
            parameters.Add("@updatedBy", updateConcernMethod.updatedBy, DbType.Guid);
            parameters.Add("@active", updateConcernMethod.active ? 1 : 0, DbType.Boolean);

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
        public async Task<ResponseViewModel> deleteConcernMethod(DeleteConcernViewModel deleteConcernMethod)
        {
            var procedureName = Constant.spDeleteConcern;
            var parameters = new DynamicParameters();
            parameters.Add("@ConcernId", deleteConcernMethod.ConcernId, DbType.Guid);
            parameters.Add("@updatedBy", deleteConcernMethod.updatedBy, DbType.Guid);
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

