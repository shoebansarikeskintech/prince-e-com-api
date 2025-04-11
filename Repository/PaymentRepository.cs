using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using static Model.ModelType;
using ViewModel;
using Common;

namespace Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DapperContext _dapperContext;
        public PaymentRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;

        public async Task<ResponseViewModel> getCheckPaymentStatus(Guid orderId)
        {
            var procedureName = Constant.spGetCheckPaymentStatus;
            var parameters = new DynamicParameters();
            parameters.Add("@orderId", orderId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Payment>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getAllOrder = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllOrder;
            }
        }

        public async Task<ResponseViewModel> getPaymentList()
        {
            var procedureName = Constant.spGetPaymentList;
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<AllPayment>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllOrder = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllOrder;
            }
        }

        public async Task<ResponseViewModel> getPaymentMode()
        {
            var procedureName = Constant.spGetAllPaymentMode;
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<PaymentMode>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllOrder = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllOrder;
            }
        }

        public async Task<ResponseViewModel> addPaymentMode(AddPaymentModeViewModel addPaymentModeViewModel)
        {
            var procedureName = Constant.spAddPaymentMode;

            //addAppRole.createdBy = Guid.NewGuid();
            var parameters = new DynamicParameters();
            parameters.Add("@paymentName", addPaymentModeViewModel.paymentName, DbType.String);
            parameters.Add("@createdBy", addPaymentModeViewModel.createdBy, DbType.Guid);

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

        public async Task<ResponseViewModel> updatePaymentMode(UpdatePaymentModeViewModel updatePaymentModeViewModel)
        {
            var procedureName = Constant.spUpdatePaymentMode;

            var parameters = new DynamicParameters();
            parameters.Add("@paymentModeId", updatePaymentModeViewModel.paymentModeId, DbType.Guid);
            parameters.Add("@paymentName", updatePaymentModeViewModel.paymentName, DbType.String);
            parameters.Add("@updatedBy", updatePaymentModeViewModel.updatedBy, DbType.Guid);
            parameters.Add("@active", updatePaymentModeViewModel.active ? 1 : 0, DbType.Boolean);

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

        public async Task<ResponseViewModel> deletePaymentMode(DeletePaymentModeViewModel deletePaymentModeViewModel)
        {
            var procedureName = Constant.spDeletePaymentMode;

            var parameters = new DynamicParameters();
            parameters.Add("@paymentModeId", deletePaymentModeViewModel.paymentModeId, DbType.Guid);
            parameters.Add("@updatedBy", deletePaymentModeViewModel.updatedBy, DbType.Guid);
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