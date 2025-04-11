using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using static Model.ModelType;
using ViewModel;
using Common;
using Azure;

namespace Repository
{
    class AdminAuthenticationRepository : IAdminAuthenticationRepository
    {
        private readonly DapperContext _dapperContext;
        public AdminAuthenticationRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<ResponseViewModel> adminUserLogin(AdminUserLoginViewModel adminUserLogin)
        {
            var procedureName = Constant.spAdminUserLogin;
            var parameters = new DynamicParameters();
            parameters.Add("@username", adminUserLogin.username, DbType.String);
            parameters.Add("@password", adminUserLogin.password, DbType.String);
            //parameters.Add("@password", EncryptDecrypt.EnryptString(loginViewModel?.password ?? string.Empty), DbType.String);

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
                ResponseViewModel returnData;
                if (result != null && result.Any())
                {
                    var validation = result.First();
                    if (validation.statusCode == 1)
                    {
                        returnData = new ResponseViewModel
                        {
                            statusCode = (int)HttpStatusCode.OK,
                            message = validation.message,
                            data = result
                        };
                    }
                    else if (validation.statusCode == 0)
                    {
                        returnData = new ResponseViewModel
                        {
                            statusCode = (int)HttpStatusCode.Conflict,
                            message = validation.message
                        };
                    }
                    else if (validation.statusCode == -1)
                    {
                        returnData = new ResponseViewModel
                        {
                            statusCode = (int)HttpStatusCode.Conflict,
                            message = validation.message
                        };
                    }
                    else
                    {
                        returnData = new ResponseViewModel
                        {
                            statusCode = (int)HttpStatusCode.BadRequest,
                            message = validation.message
                        };
                    }
                }
                else
                {
                    returnData = new ResponseViewModel
                    {
                        statusCode = (int)HttpStatusCode.NotFound,
                        message = "Something went to wrong with server error."
                    };
                }
                return returnData;
            }
        }
        public async Task<ResponseViewModel> addAdminUser(AddAdminUserViewModel addAdminUser)
        {
            var procedureName = Constant.spAddAdminUser;
            var parameters = new DynamicParameters();
            parameters.Add("@username", addAdminUser.username, DbType.String);
            parameters.Add("@name", addAdminUser.name, DbType.String);
            parameters.Add("@email", addAdminUser.email, DbType.String);
            parameters.Add("@phoneNumber", addAdminUser.phoneNumber, DbType.String);
            parameters.Add("@password", addAdminUser.password, DbType.String);

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<RegistrationValidation>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                ResponseViewModel returnData;
                if (result != null && result.Any())
                {
                    var validation = result.First();
                    if (validation.statusCode == 1)
                    {
                        returnData = new ResponseViewModel
                        {
                            statusCode = (int)HttpStatusCode.OK,
                            message = validation.message
                        };
                    }
                    else if (validation.statusCode == 0)
                    {
                        returnData = new ResponseViewModel
                        {
                            statusCode = (int)HttpStatusCode.Conflict,
                            message = validation.message
                        };
                    }
                    else
                    {
                        returnData = new ResponseViewModel
                        {
                            statusCode = (int)HttpStatusCode.BadRequest,
                            message = validation.message
                        };
                    }
                }
                else
                {
                    returnData = new ResponseViewModel
                    {
                        statusCode = (int)HttpStatusCode.NotFound,
                        message = "Something went to wrong with server error."
                    };
                }
                return returnData;
            }
        }
        public async Task<ResponseViewModel> adminSendOtp(AdminSendOtpViewModel adminSendOtp)
        {
            var procedureName = Constant.spAdminSendOtp;
            var parameters = new DynamicParameters();
            parameters.Add("@username", adminSendOtp.username, DbType.String);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var emailDetail = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Error in sending otp, please enter correct username." : "Otp sent to your email address, please enter otp.",
                    data = result
                };
                return emailDetail;
            }
        }
        public async Task<ResponseViewModel> adminVerifyOtp(AdminVerifyOtpViewModel adminVerifyOtp)
        {
            var procedureName = Constant.spAdminVerifyOtp;
            var parameters = new DynamicParameters();
            parameters.Add("@username", adminVerifyOtp.username, DbType.String);
            parameters.Add("@otp", adminVerifyOtp.otp, DbType.String);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
                ResponseViewModel returnData;
                if (result != null && result.Any())
                {
                    var validation = result.First();
                    if (validation.statusCode == 1)
                    {
                        returnData = new ResponseViewModel
                        {
                            statusCode = (int)HttpStatusCode.OK,
                            message = validation.message
                        };
                    }
                    else if (validation.statusCode == 0)
                    {
                        returnData = new ResponseViewModel
                        {
                            statusCode = (int)HttpStatusCode.Conflict,
                            message = validation.message
                        };
                    }
                    else
                    {
                        returnData = new ResponseViewModel
                        {
                            statusCode = (int)HttpStatusCode.BadRequest,
                            message = validation.message
                        };
                    }
                }
                else
                {
                    returnData = new ResponseViewModel
                    {
                        statusCode = (int)HttpStatusCode.NotFound,
                        message = "Something went to wrong with server error."
                    };
                }
                return returnData;
            }
        }
        public async Task<ResponseViewModel> adminForgotPassword(AdminForgotPasswordViewModel adminForgotPassword)
        {
            var procedureName = Constant.spAdminUpdatePassword;
            var parameters = new DynamicParameters();
            parameters.Add("@userName", adminForgotPassword.username, DbType.String);
            parameters.Add("@password", adminForgotPassword.password, DbType.String);
            //parameters.Add("@password", EncryptDecrypt.EnryptString(updatePassword?.password ?? string.Empty), DbType.String);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
                ResponseViewModel returnData;
                if (result != null && result.Any())
                {
                    var validation = result.First();
                    if (validation.statusCode == 1)
                    {
                        returnData = new ResponseViewModel
                        {
                            statusCode = (int)HttpStatusCode.OK,
                            message = validation.message
                        };
                    }
                    else if (validation.statusCode == 0)
                    {
                        returnData = new ResponseViewModel
                        {
                            statusCode = (int)HttpStatusCode.Conflict,
                            message = validation.message
                        };
                    }
                    else
                    {
                        returnData = new ResponseViewModel
                        {
                            statusCode = (int)HttpStatusCode.BadRequest,
                            message = validation.message
                        };
                    }
                }
                else
                {
                    returnData = new ResponseViewModel
                    {
                        statusCode = (int)HttpStatusCode.NotFound,
                        message = "Something went to wrong with server error."
                    };
                }
                return returnData;
            }
        }

        public async Task<ResponseViewModel> getAdminUserDetails(AdminUserGuidViewModel adminUserGuid, string username)
        {
            var procedureName = Constant.spGetAdminDetails;
            var parameters = new DynamicParameters();
            parameters.Add("@adminUserId", adminUserGuid.adminUserId, DbType.Guid);
            parameters.Add("@username", username, DbType.String);

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<AdminUserDetails>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getAllAppRole = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Get Admin User Details.",
                    data = result
                };
                return getAllAppRole;
            }
        }
        public async Task<ResponseViewModel> getAdminDashboardDetails(string username)
        {
            var procedureDashboard = Constant.spGetAdminDashboardDetails;
            var procedureTodayOrder = Constant.spGetTodayOrderList;

            var parameters = new DynamicParameters();
            parameters.Add("@username", username, DbType.String);

            using (var connection = _dapperContext.createConnection())
            {
                var resultDashboard = await connection.QueryAsync<AdminDashboard>(procedureDashboard, parameters, commandType: CommandType.StoredProcedure);
                var resultTodayOrder = await connection.QueryAsync<TodayOrderList>(procedureTodayOrder, parameters, commandType: CommandType.StoredProcedure);

                var responseDashboard = resultDashboard.FirstOrDefault();
                var responseTodayOrder = resultTodayOrder.ToList();

                var responseData = new
                {
                    pendingOrder = responseDashboard.pendingOrder,
                    todayOrder = responseDashboard.todayOrder,
                    totalOrder = responseDashboard.totalOrder,
                    returnOrder = responseDashboard.returnOrder,
                    todayOrderList = resultTodayOrder
                };

                var response = new ResponseViewModel
                {
                    statusCode = resultDashboard.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = resultDashboard.Count() == 0 ? "Data Not Found" : "Get Admin Dashboard Details.",
                    data = responseData
                };

                return response;
            }
        }
    }
}

