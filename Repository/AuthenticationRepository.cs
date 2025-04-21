using Common;
using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using ViewModel;
using static Model.ModelType;

namespace Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly DapperContext _dapperContext;
        public AuthenticationRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<ResponseViewModel> appLogin(AppLoginViewModel appLogin)
        {
            var procedureName = Constant.spAppLogin;
            var parameters = new DynamicParameters();
            parameters.Add("@username", appLogin.username, DbType.String);
            parameters.Add("@password", appLogin.password, DbType.String);
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
        public async Task<ResponseViewModel> sendOtp(SendOtpViewModel sendOtp)
        {
            var procedureName = Constant.spSendOtp;
            var parameters = new DynamicParameters();
            parameters.Add("@username", sendOtp.username, DbType.String);
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
        public async Task<ResponseViewModel> verifyOtp(VerifyOtpViewModel verifyOtp)
        {
            var procedureName = Constant.spVerifyOtp;
            var parameters = new DynamicParameters();
            parameters.Add("@username", verifyOtp.username, DbType.String);
            parameters.Add("@otp", verifyOtp.otp, DbType.String);
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
        public async Task<ResponseViewModel> forgotPassword(ForgotPasswordViewModel forgotPassword)
        {
            var procedureName = Constant.spUpdatePassword;
            var parameters = new DynamicParameters();
            parameters.Add("@userName", forgotPassword.username, DbType.String);
            parameters.Add("@password", forgotPassword.password, DbType.String);
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
        public async Task<ResponseViewModel> addAppUser(AddAppUserViewModel addAppUser)
        {
            var procedureName = Constant.spAddAppUser;
            var parameters = new DynamicParameters();
            parameters.Add("@username", addAppUser.username, DbType.String);
            parameters.Add("@name", addAppUser.name, DbType.String);
            parameters.Add("@email", addAppUser.email, DbType.String);
            parameters.Add("@phoneNumber", addAppUser.phoneNumber, DbType.String);
            parameters.Add("@password", addAppUser.password, DbType.String);
            parameters.Add("@Age", addAppUser.Age, DbType.String);
            parameters.Add("@Gender", addAppUser.Gender, DbType.String);
            parameters.Add("@Skintype", addAppUser.Skintype, DbType.String);
            parameters.Add("@IsSkinSensitve", addAppUser.IsSkinSensitve, DbType.String);

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

        public async Task<ResponseViewModel> updateAppUser(UpdateAppUserViewModel updateAppUser)
        {
            var procedureName = Constant.SpUpdateAppuser;
            var parameters = new DynamicParameters();
            var returnData = new ResponseViewModel();

            try
            {
                parameters.Add("@userId", updateAppUser.userId, DbType.Guid);

                if (updateAppUser.age != null)
                    parameters.Add("@age", updateAppUser.age, DbType.Int32);

                if (!string.IsNullOrEmpty(updateAppUser.gender))
                    parameters.Add("@gender", updateAppUser.gender, DbType.String);

                if (!string.IsNullOrEmpty(updateAppUser.skinType))
                    parameters.Add("@skinType", updateAppUser.skinType, DbType.String);

                if (updateAppUser.isSkinSensitve != null)
                    parameters.Add("@isSkinSensitve", updateAppUser.isSkinSensitve, DbType.String);

                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<RegistrationValidation>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                    if (result != null && result.Any())
                    {
                        var validation = result.First();
                        returnData.statusCode = validation.statusCode == 1 ? (int)HttpStatusCode.OK :
                                                validation.statusCode == 0 ? (int)HttpStatusCode.Conflict :
                                                (int)HttpStatusCode.BadRequest;
                        returnData.message = validation.message;
                    }
                    else
                    {
                        returnData.statusCode = (int)HttpStatusCode.NotFound;
                        returnData.message = "Something went wrong with server error.";
                    }
                }
            }
            catch (Exception ex)
            {
                returnData.statusCode = (int)HttpStatusCode.InternalServerError;
                returnData.message = $"Exception occurred: {ex.Message}";
                // Optionally log the exception here
            }

            return returnData;
        }

    }
}
