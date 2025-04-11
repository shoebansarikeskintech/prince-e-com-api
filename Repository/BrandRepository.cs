using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using static Model.ModelType;
using ViewModel;
using Common;

namespace Repository
{
   public class BrandRepository : IBrandRepository
    {
        private readonly DapperContext _dapperContext;
        public BrandRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;
        public async Task<ResponseViewModel> getByIdBrand(Guid brandId)
        {
            var procedureName = Constant.spGetByIdBrand;
            var parameters = new DynamicParameters();
            parameters.Add("@brandId", brandId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Brand>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getbyIdBrand = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getbyIdBrand;
            }
        }
        public async Task<ResponseViewModel> getAllBrand()
        {
            var procedureName = Constant.spGetAllBrand;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Brand>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllBrand = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllBrand;
            }
        }
        public async Task<ResponseViewModel> getAllBrandForUser()
        {
            var procedureName = Constant.spGetAllBrandForUser;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Brand>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllBrand = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllBrand;
            }
        }
        public async Task<ResponseViewModel> addBrand(AddBrandViewModel addBrand)
        {
            var procedureName = Constant.spAddBrand;
            var parameters = new DynamicParameters();
            parameters.Add("@name", addBrand.name, DbType.String);
            parameters.Add("@description", addBrand.description, DbType.String);
            parameters.Add("@createdBy", addBrand.createdBy, DbType.Guid);

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
        public async Task<ResponseViewModel> updateBrand(UpdateBrandViewModel updateBrand)
        {
            var procedureName = Constant.spUpdateBrand;
            var parameters = new DynamicParameters();
            parameters.Add("@brandId", updateBrand.brandId, DbType.Guid);
            parameters.Add("@name", updateBrand.name, DbType.String);
            parameters.Add("@description", updateBrand.description, DbType.String);
            parameters.Add("@active", updateBrand.active ? 1 : 0, DbType.Boolean);
            parameters.Add("@updatedBy", updateBrand.updatedBy, DbType.Guid);
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
        public async Task<ResponseViewModel> deleteBrand(DeleteBrandViewModel deleteBrand)
        {
            var procedureName = Constant.spDeleteBrand;
            var parameters = new DynamicParameters();
            parameters.Add("@brandId", deleteBrand.brandId, DbType.Guid);
            parameters.Add("@updatedBy", deleteBrand.updatedBy, DbType.Guid);
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