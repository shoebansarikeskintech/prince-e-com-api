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
        //public async Task<ResponseViewModel> getAdminDashboardDetails(string username)
        //{
        //    var procedureDashboard = Constant.spGetAdminDashboardDetails;
        //    var procedureTodayOrder = Constant.spGetTodayOrderList;

        //    var parameters = new DynamicParameters();
        //    parameters.Add("@username", username, DbType.String);

        //    try
        //    {
        //        using (var connection = _dapperContext.createConnection())
        //        {
        //            var resultDashboard = await connection.QueryAsync<AdminDashboardToday>(procedureDashboard, parameters, commandType: CommandType.StoredProcedure);
        //            //var resultTodayOrder = await connection.QueryAsync<TodayOrderList>(procedureTodayOrder, parameters, commandType: CommandType.StoredProcedure);

        //            var responseDashboard = resultDashboard.FirstOrDefault();

        //            // Check if dashboard is null or contains error status
        //            if (responseDashboard == null)
        //            {
        //                return new ResponseViewModel
        //                {
        //                    statusCode = (int)HttpStatusCode.NotFound,
        //                    message = "Data Not Found",
        //                    data = null
        //                };
        //            }

        //            if (responseDashboard.StatusCode == -1 || responseDashboard.StatusCode == -2)
        //            {
        //                return new ResponseViewModel
        //                {
        //                    statusCode = (int)HttpStatusCode.Unauthorized,
        //                    message = responseDashboard.Message ?? "Unauthorized access or error occurred.",
        //                    data = null
        //                };
        //            }

        //            var responseTodayOrder = resultDashboard.ToList();

        //            var responseData = new
        //            {
        //                totalUsers = responseDashboard.totalUsers,
        //                totalOrder = responseDashboard.totalOrder,
        //                pendingOrder = responseDashboard.pendingOrder,
        //                todayOrder = responseDashboard.todayOrder,
        //                returnOrder = responseDashboard.returnOrder,
        //                lowProduct = responseDashboard.lowProduct,
        //                outOfStock = responseDashboard.outOfStock,
        //                totalProduct = responseDashboard.totalProduct,
        //                totalRevenue = responseDashboard.totalRevenue,
        //                todayRevenue = responseDashboard.todayRevenue,
        //                cancelOrder = responseDashboard.cancelOrder,
        //                todayOrderList = responseTodayOrder
        //            };

        //            return new ResponseViewModel
        //            {
        //                statusCode = (int)HttpStatusCode.OK,
        //                message = "Get Admin Dashboard Details.",
        //                data = responseData
        //            };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResponseViewModel
        //        {
        //            statusCode = (int)HttpStatusCode.InternalServerError,
        //            message = "An error occurred while fetching admin dashboard details.",
        //            data = ex.Message  // optionally return error for debugging
        //        };
        //    }
        //}

        public async Task<ResponseViewModel> getAdminDashboardDetails(string username)
        {
            var procedureName = Constant.spGetAdminDashboardDetails;
            var parameters = new DynamicParameters();

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@username", username);
                    var result = await connection.QueryAsync<AdminDashboardToday>(procedureName,param, commandType: CommandType.StoredProcedure);

                    var getAllAppRole = new ResponseViewModel
                    {
                        statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                        message = result.Count() == 0 ? "Data Not Found" : "Get Admin Dashboard Users Details.",
                        data = result
                    };

                    return getAllAppRole;
                }
            }
            catch (Exception ex)
            {
                // Exception log karlo agar chaho toh
                Console.Error.WriteLine($"Error in getAllAdminList: {ex.Message}");

                return new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = "Something went wrong while fetching admin list."
                };
            }
        }
        public async Task<ResponseViewModel> getAllAdminList()
        {
            var procedureName = Constant.spGetAllAdminList;
            var parameters = new DynamicParameters();

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<AdminAllUserDetails>(procedureName, commandType: CommandType.StoredProcedure);

                    var getAllAppRole = new ResponseViewModel
                    {
                        statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                        message = result.Count() == 0 ? "Data Not Found" : "Get Admin User Details.",
                        data = result
                    };

                    return getAllAppRole;
                }
            }
            catch (Exception ex)
            {
                // Exception log karlo agar chaho toh
                Console.Error.WriteLine($"Error in getAllAdminList: {ex.Message}");

                return new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = "Something went wrong while fetching admin list."
                };
            }
        }


        public async Task<ResponseViewModel> updateAdminStatusActivate(string adminuserId)
        {
            var procedureName = Constant.spUpdateAdminStatusActivate;
            var parameters = new DynamicParameters();
            parameters.Add("@userId", adminuserId);

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

                var updateAdminStatusActivate = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "User activated successfully." : "User activated successfully.",
                    data = result
                };

                return updateAdminStatusActivate;
            }
        }

        public async Task<ResponseViewModel> updateAdminStatusDeActivate(string adminuserId)
        {
            var procedureName = Constant.spUpdateAdminStatusDeActivate;
            var parameters = new DynamicParameters();
            parameters.Add("@userId", adminuserId);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var updateAdminStatusDeActivate = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "User DeActivated Suscessfully." : "User DeActivated Suscessfully.",
                    data = result
                };
                return updateAdminStatusDeActivate;
            }
        }
    }
}

