using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using static Model.ModelType;
using ViewModel;
using Common;

namespace Repository
{
   public class ShippingRepository : IShippingRepository
    {
        private readonly DapperContext _dapperContext;
        public ShippingRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;
        public async Task<ResponseViewModel> getByIdShipping(Guid shippingId)
        {
            var procedureName = Constant.spGetByIdShipping;
            var parameters = new DynamicParameters();
            parameters.Add("@shippingId", shippingId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Shipping>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getbyIdShipping = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getbyIdShipping;
            }
        }
        public async Task<ResponseViewModel> getAllShipping()
        {
            var procedureName = Constant.spGetAllShipping;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Shipping>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllShipping = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllShipping;
            }
        }
        public async Task<ResponseViewModel> addShipping(AddShippingViewModel addShipping)
        {
            var procedureName = Constant.spAddShipping;
            var parameters = new DynamicParameters();
            parameters.Add("@orderId", addShipping.orderId, DbType.Guid);
            parameters.Add("@trackingNo", addShipping.trackingNo, DbType.String);
            parameters.Add("@carrier", addShipping.carrier, DbType.String);
            parameters.Add("@estimateDelivery", addShipping.estimateDelivery, DbType.DateTime);
            parameters.Add("@status", addShipping.status, DbType.String);
            parameters.Add("@createdBy", addShipping.createdBy, DbType.Guid);

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
        public async Task<ResponseViewModel> updateShipping(UpdateShippingViewModel updateShipping)
        {
            var procedureName = Constant.spUpdateShipping;
            var parameters = new DynamicParameters();
            parameters.Add("@shippingId", updateShipping.shippingId, DbType.Guid);
            parameters.Add("@orderId", updateShipping.orderId, DbType.Guid);
            parameters.Add("@trackingNo", updateShipping.trackingNo, DbType.String);
            parameters.Add("@carrier", updateShipping.carrier, DbType.String);
            parameters.Add("@estimateDelivery", updateShipping.estimateDelivery, DbType.DateTime);
            parameters.Add("@status", updateShipping.status, DbType.String);
            parameters.Add("@updatedBy", updateShipping.updatedBy, DbType.Guid);

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
        public async Task<ResponseViewModel> deleteShipping(DeleteShippingViewModel deleteShipping)
        {
            var procedureName = Constant.spDeleteShipping;
            var parameters = new DynamicParameters();
            parameters.Add("@shippingId", deleteShipping.shippingId, DbType.Guid);
            parameters.Add("@orderId", deleteShipping.orderId, DbType.Guid);
            parameters.Add("@updatedBy", deleteShipping.updatedBy, DbType.Guid);
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
