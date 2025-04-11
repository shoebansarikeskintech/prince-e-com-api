using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using ViewModel;
using Common;
using static Model.ModelType;

namespace Repository
{
  public class NotificationRepository : INotificationRepository
    {
        private readonly DapperContext _dapperContext;
        public NotificationRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;
        public async Task<ResponseViewModel> getByIdNotification(Guid notificationId)
        {
            var procedureName = Constant.spGetByIdNotification;
            var parameters = new DynamicParameters();
            parameters.Add("@notificationId", notificationId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Notification>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getbyIdNotification = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getbyIdNotification;
            }         
        }
        public async Task<ResponseViewModel> getAllNotification()
        {
            var procedureName = Constant.spGetAllNotification;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Notification>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllNotification = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllNotification;
            }
        }
        public async Task<ResponseViewModel> getAllNotificationForUser()
        {
            var procedureName = Constant.spGetAllNotificationForUser;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Notification>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllNotification = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllNotification;
            }
        }
        public async Task<ResponseViewModel> addNotification(AddNotificationViewModel addNotification)
        {
            var procedureName = Constant.spAddNotification;
            var parameters = new DynamicParameters();
            parameters.Add("@title", addNotification.title);
            parameters.Add("@description", addNotification.descrption, DbType.String);
            parameters.Add("@status", addNotification.status, DbType.String);
            parameters.Add("@createdBy", addNotification.createdBy, DbType.Guid);
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
        public async Task<ResponseViewModel> updateNotification(UpdateNotificationViewModel updateNotification)
        {
            var procedureName = Constant.spUpdateNotification;

            var parameters = new DynamicParameters();
            parameters.Add("@notificationId", updateNotification.notificationId, DbType.Guid);
            parameters.Add("@title", updateNotification.title, DbType.String);
            parameters.Add("@description", updateNotification.descrption, DbType.String);
            parameters.Add("@status", updateNotification.status, DbType.String);
            parameters.Add("@updatedBy", updateNotification.updatedBy, DbType.Guid);

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
                }
                return result;
            }
        }
        public async Task<ResponseViewModel> deleteNotification(DeleteNotificationViewModel deleteNotification)
        {
            var procedureName = Constant.spDeleteNotification;
            var parameters = new DynamicParameters();
            parameters.Add("@notificationId", deleteNotification.notificationId, DbType.Guid);
            parameters.Add("@updatedBy", deleteNotification.updatedBy, DbType.Guid);
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
                }
                return result;
            }
        }
    }
}
