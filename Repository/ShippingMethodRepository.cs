using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using ViewModel;
using static Model.ModelType;
using Common;
using System.Diagnostics.Metrics;

namespace Repository
{
    public class ShippingMethodRepository : IShippingMethodRepository
    {
        private readonly DapperContext _dapperContext;
        public ShippingMethodRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;
        public async Task<ResponseViewModel> getAllShippingMethod()
        {
            var procedureName = Constant.spGetAllShippingMethod;
            var parameters = new DynamicParameters();
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<ShippingMethod>(procedureName, null, commandType: CommandType.StoredProcedure);
                var ShippingMethodList = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Shipping Method Data Found",
                    data = result
                };
                return ShippingMethodList;
            }
        }

        public async Task<ResponseViewModel> addShippingMethod(AddShippingMethodViewModel addShippingMethod)
        {
            var procedureName = Constant.spAddShippingMethod;
            var parameters = new DynamicParameters();           
            parameters.Add("@name", addShippingMethod.name, DbType.String);
            parameters.Add("@courier", addShippingMethod.courier, DbType.String);
            parameters.Add("@shippingZone", addShippingMethod.shippingZone, DbType.String);
            parameters.Add("@baseCost", addShippingMethod.baseCost, DbType.String);
            parameters.Add("@costPerKg", addShippingMethod.costPerKg, DbType.String);
            parameters.Add("@maxWeightLimit", addShippingMethod.maxWeightLimit, DbType.String);
            parameters.Add("@minOrderValue", addShippingMethod.minOrderValue, DbType.String);
            parameters.Add("@trackingURL", addShippingMethod.trackingURL, DbType.String);
            parameters.Add("@createdBy", addShippingMethod.createdBy, DbType.Guid);
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

        public async Task<ResponseViewModel> updateShippingMethod(UpdateShippingMethodViewModel updateShippingMethod)
        {
            var procedureName = Constant.spUpdateShippingmethod;
            var parameters = new DynamicParameters();
            parameters.Add("@shippingMethodId", updateShippingMethod.shippingMethodId, DbType.Guid);
            parameters.Add("@name", updateShippingMethod.name, DbType.String);
            parameters.Add("@courier", updateShippingMethod.courier, DbType.String);
            parameters.Add("@shippingZone", updateShippingMethod.shippingZone, DbType.String);
            parameters.Add("@baseCost", updateShippingMethod.baseCost, DbType.String);
            parameters.Add("@costPerKg", updateShippingMethod.costPerKg, DbType.String);
            parameters.Add("@maxWeightLimit", updateShippingMethod.maxWeightLimit, DbType.String);
            parameters.Add("@minOrderValue", updateShippingMethod.minOrderValue, DbType.String);
            parameters.Add("@trackingURL", updateShippingMethod.trackingURL, DbType.String);
            parameters.Add("@updatedBy", updateShippingMethod.updatedBy, DbType.Guid);
            parameters.Add("@active", updateShippingMethod.active ? 1 : 0, DbType.Boolean);

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
        public async Task<ResponseViewModel> deleteShippingMethod(DeleteShippingMethodViewModel deleteShippingMethod)
        {
            var procedureName = Constant.spDeleteShippingMethod;
            var parameters = new DynamicParameters();
            parameters.Add("@shippingMethodId", deleteShippingMethod.shippingMethodId, DbType.Guid);
            parameters.Add("@updatedBy", deleteShippingMethod.updatedBy, DbType.Guid);
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
