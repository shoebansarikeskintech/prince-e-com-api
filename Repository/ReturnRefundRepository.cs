using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using static Model.ModelType;
using ViewModel;
using Common;

namespace Repository
{
   public class ReturnRefundRepository : IReturnRefundRepository
    {
        private readonly DapperContext _dapperContext;
        public ReturnRefundRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;
        public async Task<ResponseViewModel> getAllRefundOrder(Guid adminUserId)
        {
            var procedureName = Constant.spGetAllRefundOrder;
            var parameters = new DynamicParameters();
            parameters.Add("@adminUserId", adminUserId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<AllRefundOrder>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getAllOrder = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllOrder;
            }
        }
        public async Task<ResponseViewModel> updateRefundOrderStatus(UpdateRefundOrderStatusViewModel updateRefundOrderStatus)
        {
            var procedureName = Constant.spUpdateRefundOrderStatus;
            var parameters = new DynamicParameters();
            parameters.Add("@adminUserId", updateRefundOrderStatus.adminUserId, DbType.Guid);
            parameters.Add("@returnId", updateRefundOrderStatus.returnId, DbType.Guid);
            parameters.Add("@returnStatus", updateRefundOrderStatus.returnStatus, DbType.String);
            parameters.Add("@refundStatus", updateRefundOrderStatus.refundStatus, DbType.String);
            parameters.Add("@updatedBy", updateRefundOrderStatus.updatedBy, DbType.Guid);
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
