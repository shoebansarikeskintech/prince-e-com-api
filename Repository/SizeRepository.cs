using Common;
using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using ViewModel;
using static Model.ModelType;

namespace Repository
{
   public class SizeRepository: ISizeRepository
    {
        private readonly DapperContext _dapperContext;
        public SizeRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;
        public async Task<ResponseViewModel> getByIdSize(Guid sizeId)
        {
            var procedureName = Constant.spGetByIdSize;
            var parameters = new DynamicParameters();
            parameters.Add("@sizeId", sizeId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<SizeRes>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getbyIdSize = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getbyIdSize;
            }
        }

        public async Task<ResponseViewModel> getAllSize()
        {
            var procedureName = Constant.spGetAllSize;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<SizeRes>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllSize = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllSize;
            }
        }

        public async Task<ResponseViewModel> getAllSizeForUser()
        {
            var procedureName = Constant.spGetAllSizeForUser;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<SizeRes>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllSizeForUser = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllSizeForUser;
            }
        }

        public async Task<ResponseViewModel> addSize(AddSizeViewModel addSize)
        {
            var procedureName = Constant.spAddSize;
            var parameters = new DynamicParameters();
            parameters.Add("@name", addSize.name, DbType.String);
            parameters.Add("@code", addSize.code, DbType.String);
            parameters.Add("@createdBy", addSize.createdBy, DbType.Guid);
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
        public async Task<ResponseViewModel> updateSize(UpdateSizeViewModel updateSize)
        {
            var procedureName = Constant.spUpdateSize;
            var parameters = new DynamicParameters();
            parameters.Add("@sizeId", updateSize.sizeId, DbType.Guid);
            parameters.Add("@name", updateSize.name, DbType.String);
            parameters.Add("@code", updateSize.code, DbType.String);
            parameters.Add("@active", updateSize.active ? 1 : 0, DbType.Boolean);
            parameters.Add("@updatedBy", updateSize.updatedBy, DbType.Guid);
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
        public async Task<ResponseViewModel> deleteSize(DeleteSizeViewModel deleteSize)
        {
            var procedureName = Constant.spDeleteSize;
            var parameters = new DynamicParameters();
            parameters.Add("@sizeId", deleteSize.sizeId, DbType.Guid);
            parameters.Add("@updatedBy", deleteSize.updatedBy, DbType.Guid);
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
