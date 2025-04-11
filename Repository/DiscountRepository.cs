using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using static Model.ModelType;
using ViewModel;
using Common;

namespace Repository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly DapperContext _dapperContext;
        public DiscountRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;
        public async Task<ResponseViewModel> getByIdDiscount(Guid discountId)
        {
            var procedureName = Constant.spGetByIdDiscount;
            var parameters = new DynamicParameters();
            parameters.Add("@discountId", discountId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Discount>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getbyIdDiscount = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getbyIdDiscount;
            }
        }
        public async Task<ResponseViewModel> getAllDiscount()
        {
            var procedureName = Constant.spGetAllDiscount;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Discount>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllDiscount = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllDiscount;
            }
        }
        public async Task<ResponseViewModel> addDiscount(AddDiscountViewModel addDiscount)
        {
            var procedureName = Constant.spAddDiscount;
            var parameters = new DynamicParameters();
            parameters.Add("@productId", addDiscount.productId, DbType.Guid);
            parameters.Add("@code", addDiscount.code, DbType.String);
            parameters.Add("@discountType", addDiscount.discountType, DbType.String);
            parameters.Add("@discount", addDiscount.discount, DbType.String);
            parameters.Add("@productAmount", addDiscount.productAmount, DbType.String);
            parameters.Add("@validDate", addDiscount.validDate, DbType.DateTime);
            parameters.Add("@expireDate", addDiscount.expireDate, DbType.DateTime);
            parameters.Add("@createdBy", addDiscount.createdBy, DbType.Guid);

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
        public async Task<ResponseViewModel> updateDiscount(UpdateDiscountViewModel updateDiscount)
        {
            var procedureName = Constant.spUpdateDiscount;
            var parameters = new DynamicParameters();
            parameters.Add("@discountId", updateDiscount.discountId, DbType.Guid);
            parameters.Add("@productId", updateDiscount.productId, DbType.Guid);
            parameters.Add("@code", updateDiscount.code, DbType.String);
            parameters.Add("@discountType", updateDiscount.discountType, DbType.String);
            parameters.Add("@discount", updateDiscount.discount, DbType.String);
            parameters.Add("@productAmount", updateDiscount.productAmount, DbType.String);
            parameters.Add("@validDate", updateDiscount.validDate, DbType.DateTime);
            parameters.Add("@expireDate", updateDiscount.expireDate, DbType.DateTime);
            parameters.Add("@updatedBy", updateDiscount.updatedBy, DbType.Guid);
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
        public async Task<ResponseViewModel> deleteDiscount(DeleteDiscountViewModel deleteDiscount)
        {
            var procedureName = Constant.spDeleteDiscount;
            var parameters = new DynamicParameters();
            parameters.Add("@productId", deleteDiscount.productId, DbType.Guid);
            parameters.Add("@discountId", deleteDiscount.discountId, DbType.Guid);
            parameters.Add("@updatedBy", deleteDiscount.updatedBy, DbType.Guid);

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
