using Dapper;
using RepositoryContract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Common;
using static Model.ModelType;

namespace Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly DapperContext _dapperContext;
        public IngredientRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;

        public async Task<ResponseViewModel> getAllIngredientMethod()
        {
            var procedureName = Constant.spGetAllIngredient;
            var parameters = new DynamicParameters();

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<IngredientMethod>(
                        procedureName,
                        null,
                        commandType: CommandType.StoredProcedure
                    );

                    var IngredientMethodList = new ResponseViewModel
                    {
                        statusCode = result.Any() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound,
                        message = result.Any() ? "Ingredien Data Found" : "Data Not Found",
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

        public async Task<ResponseViewModel> addIngredientMethod(AddIngredientViewModel addIngredientMethod)
        {
            var procedureName = Constant.spAddIngredient;
            var parameters = new DynamicParameters();
            parameters.Add("@name", addIngredientMethod.name, DbType.String);
            parameters.Add("@description", addIngredientMethod.description, DbType.String);          
            parameters.Add("@createdBy", addIngredientMethod.createdBy, DbType.Guid);

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


        public async Task<ResponseViewModel> updateIngredientMethod(UpdateIngredientViewModel updateUpdateIngredientMethod)
        {
            var procedureName = Constant.spUpdateIngredientId;
            var parameters = new DynamicParameters();
            parameters.Add("@ingredientId", updateUpdateIngredientMethod.ingredientId, DbType.Guid);
            parameters.Add("@name", updateUpdateIngredientMethod.name, DbType.String);
            parameters.Add("@description", updateUpdateIngredientMethod.description, DbType.String);           
            parameters.Add("@updatedBy", updateUpdateIngredientMethod.updatedBy, DbType.Guid);
            parameters.Add("@active", updateUpdateIngredientMethod.active ? 1 : 0, DbType.Boolean);

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
        public async Task<ResponseViewModel> deleteIngredientMethod(DeleteIngredientViewModel deleteIngredientMethod)
        {
            var procedureName = Constant.spDeleteIngredient;
            var parameters = new DynamicParameters();
            parameters.Add("@ingredientId", deleteIngredientMethod.ingredientId, DbType.Guid);
            parameters.Add("@updatedBy", deleteIngredientMethod.updatedBy, DbType.Guid);
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
