using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using static Model.ModelType;
using ViewModel;
using Common;

namespace Repository
{
   public class SellerRepository : ISellerRepository
    {
        private readonly DapperContext _dapperContext;
        public SellerRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;
        public async Task<ResponseViewModel> getByIdSeller(Guid sellerId)
        {
            var procedureName = Constant.spGetByIdSeller;
            var parameters = new DynamicParameters();
            parameters.Add("@sellerId", sellerId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Seller>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getbyIdSeller = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getbyIdSeller;
            }
        }

        public async Task<ResponseViewModel> getAllSeller()
        {
            var procedureName = Constant.spGetAllSeller;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Seller>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllSeller = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllSeller;
            }
        }
        public async Task<ResponseViewModel> getAllSellerForUser()
        {
            var procedureName = Constant.spGetAllSellerForUser;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Seller>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllSeller = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllSeller;
            }
        }

        public async Task<ResponseViewModel> addSeller(AddSellerViewModel addSeller)
        {
            var procedureName = Constant.spAddSeller;
            var parameters = new DynamicParameters();
            parameters.Add("@name", addSeller.name, DbType.String);
            parameters.Add("@mobile", addSeller.@mobile, DbType.String);
            parameters.Add("@email", addSeller.@email, DbType.String);
            parameters.Add("@streetAddress", addSeller.@streetAddress, DbType.String);
            parameters.Add("@state", addSeller.state, DbType.String);
            parameters.Add("@city", addSeller.@city, DbType.String);
            parameters.Add("@pincode", addSeller.@pincode, DbType.String);
            parameters.Add("@country", addSeller.@country, DbType.String);
            parameters.Add("@description", addSeller.@description, DbType.String);
            parameters.Add("@createdBy", addSeller.createdBy, DbType.Guid);

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
        public async Task<ResponseViewModel> updateSeller(UpdateSellerViewModel updateSeller)
        {
            var procedureName = Constant.spUpdateSeller;
            var parameters = new DynamicParameters();
            parameters.Add("@sellerId", updateSeller.sellerId, DbType.Guid);
            parameters.Add("@name", updateSeller.name, DbType.String);
            parameters.Add("@mobile", updateSeller.mobile, DbType.String);
            parameters.Add("@email", updateSeller.email, DbType.String);
            parameters.Add("@streetAddress", updateSeller.streetAddress, DbType.String);
            parameters.Add("@state", updateSeller.state, DbType.String);
            parameters.Add("@city", updateSeller.city, DbType.String);
            parameters.Add("@pincode", updateSeller.pincode, DbType.String);
            parameters.Add("@country", updateSeller.country, DbType.String);
            parameters.Add("@description", updateSeller.description, DbType.String);
            parameters.Add("@active", updateSeller.active ? 1 : 0, DbType.Boolean);
            parameters.Add("@updatedBy", updateSeller.updatedBy, DbType.Guid);
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
        public async Task<ResponseViewModel> deleteSeller(DeleteSellerViewModel deleteSeller)
        {
            var procedureName = Constant.spDeleteSeller;
            var parameters = new DynamicParameters();
            parameters.Add("@sellerId", deleteSeller.sellerId, DbType.Guid);
            parameters.Add("@updatedBy", deleteSeller.updatedBy, DbType.Guid);
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