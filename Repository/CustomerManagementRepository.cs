using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using static Model.ModelType;
using ViewModel;
using Common;
using System.ComponentModel.DataAnnotations;

namespace Repository
{
    public class CustomerManagementRepository : ICustomerManagementRepository
    {
        private readonly DapperContext _dapperContext;
        public CustomerManagementRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;

        public async Task<ResponseViewModel> getAllCustomer()
        {
            var procedureName = Constant.spGetAllAppUser;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<AppUser>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllAppUser = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "App User Data Found",
                    data = result
                };
                return getAllAppUser;
            }
        }
        public async Task<ResponseViewModel> getAllOrderByUser(string username)
        {
            var procedureName = Constant.spGetAllOrderByUserId;

            using (var connection = _dapperContext.createConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@username", username, DbType.String);
                var result = await connection.QueryAsync<AllOrderByUserId>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getAllAppUser = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllAppUser;
            }


        }
        public async Task<ResponseViewModel> getAppUserProfileDetails(Guid userId)
        {
            var procedureName = Constant.spAppUserGetProfileDetails;

            using (var connection = _dapperContext.createConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@userId", userId, DbType.Guid);
                var result = await connection.QueryAsync<UserProfile>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getAllAppUser = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllAppUser;
            }


        }
        public async Task<ResponseViewModel> appUserUpdateProfile(UpdateProfileViewModel updateProfile)
        {
            var procedureName = Constant.spAppUserUpdateProfile;
            var parameters = new DynamicParameters();
            parameters.Add("@userId", updateProfile.userId, DbType.Guid);
            parameters.Add("@firstName", updateProfile.firstName, DbType.String);
            parameters.Add("@middleName", updateProfile.middleName, DbType.String);
            parameters.Add("@lastName", updateProfile.lastName, DbType.String);
            parameters.Add("@updatedBy", updateProfile.updatedBy, DbType.Guid);
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
        public async Task<ResponseViewModel> appUserUpdatePassword(UpdatePasswordViewModel updatePassword)
        {
            var procedureName = Constant.spAppUserUpdatePassword;

            using (var connection = _dapperContext.createConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@userId", updatePassword.userId, DbType.Guid);
                parameters.Add("@password", updatePassword.password, DbType.String);
                parameters.Add("@updatedBy", updatePassword.updatedBy, DbType.String);
        
          
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
