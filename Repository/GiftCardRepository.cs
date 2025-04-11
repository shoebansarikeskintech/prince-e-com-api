using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using static Model.ModelType;
using ViewModel;
using Common;

namespace Repository
{
    public class GiftCardRepository : IGiftCardRepository
    {
        private readonly DapperContext _dapperContext;
        public GiftCardRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;
        public async Task<ResponseViewModel> getByIdGiftCard(Guid giftCardId)
        {
            var procedureName = Constant.spGetByIdGiftCard;
            var parameters = new DynamicParameters();
            parameters.Add("@giftCardId", giftCardId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<GiftCard>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getbyIdGiftCard = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getbyIdGiftCard;
            }
        }
        public async Task<ResponseViewModel> getAllGiftCard()
        {
            var procedureName = Constant.spGetAllGiftCard;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<GiftCard>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllGiftCard = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllGiftCard;
            }
        }
        public async Task<ResponseViewModel> addGiftCard(AddGiftCardViewModel addGiftCard)
        {
            var procedureName = Constant.spAddGiftCard;
            var parameters = new DynamicParameters();
            parameters.Add("@appUserId", addGiftCard.appUserId, DbType.Guid);
            parameters.Add("@cardNumber", addGiftCard.cardNumber, DbType.String);
            parameters.Add("@balance", addGiftCard.balance, DbType.String);
            parameters.Add("@status", addGiftCard.status, DbType.String);
            parameters.Add("@issueDate", addGiftCard.issueDate, DbType.DateTime);
            parameters.Add("@expireDate", addGiftCard.expireDate, DbType.DateTime);
            parameters.Add("@createdBy", addGiftCard.createdBy, DbType.Guid);
 
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
        public async Task<ResponseViewModel> updateGiftCard(UpdateGiftCardViewModel updateGiftCard)
        {
            var procedureName = Constant.spUpdateGiftCard;
            var parameters = new DynamicParameters();
            parameters.Add("@giftCardId", updateGiftCard.giftCardId, DbType.Guid);
            parameters.Add("@appUserId", updateGiftCard.appUserId, DbType.Guid);
            parameters.Add("@cardNumber", updateGiftCard.cardNumber, DbType.String);
            parameters.Add("@balance", updateGiftCard.balance, DbType.String);
            parameters.Add("@status", updateGiftCard.status, DbType.String);
            parameters.Add("@issueDate", updateGiftCard.issueDate, DbType.DateTime);
            parameters.Add("@expireDate", updateGiftCard.expireDate, DbType.DateTime);
            parameters.Add("@updatedBy", updateGiftCard.updatedBy, DbType.Guid);
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
        public async Task<ResponseViewModel> deleteGiftCard(DeleteGiftCardViewModel deleteGiftCard)
        {
            var procedureName = Constant.spDeleteGiftCard;
            var parameters = new DynamicParameters();
            parameters.Add("@giftCardId", deleteGiftCard.giftCardId, DbType.Guid);
            parameters.Add("@appUserId", deleteGiftCard.appUserId, DbType.Guid);
            parameters.Add("@updatedBy", deleteGiftCard.updatedBy, DbType.Guid);
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