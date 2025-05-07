using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using ViewModel;
using static Model.ModelType;
using Common;
using System.Diagnostics.Metrics;
using Microsoft.Data.SqlClient;

namespace Repository
{
    public class ShippingMethodRepository : IShippingMethodRepository
    {
        private readonly DapperContext _dapperContext;
        public ShippingMethodRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;
        public async Task<ResponseViewModel> getAllShippingMethod()
        {
            var procedureName = Constant.spGetAllShippingMethod;
            var parameters = new DynamicParameters();
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<ShippingMethod>(procedureName, null, commandType: CommandType.StoredProcedure);
                var ShippingMethodList = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Shipping Method Data Found",
                    data = result
                };
                return ShippingMethodList;
            }
        }

        public async Task<ResponseViewModel> addShippingMethod(AddShippingMethodViewModel addShippingMethod)
        {
            var procedureName = Constant.spAddShippingMethod;
            var parameters = new DynamicParameters();           
            parameters.Add("@name", addShippingMethod.name, DbType.String);
            parameters.Add("@courier", addShippingMethod.courier, DbType.String);
            parameters.Add("@shippingZone", addShippingMethod.shippingZone, DbType.String);
            parameters.Add("@baseCost", addShippingMethod.baseCost, DbType.String);
            parameters.Add("@costPerKg", addShippingMethod.costPerKg, DbType.String);
            parameters.Add("@maxWeightLimit", addShippingMethod.maxWeightLimit, DbType.String);
            parameters.Add("@minOrderValue", addShippingMethod.minOrderValue, DbType.String);
            parameters.Add("@trackingURL", addShippingMethod.trackingURL, DbType.String);
            parameters.Add("@createdBy", addShippingMethod.createdBy, DbType.Guid);
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

        public async Task<ResponseViewModel> updateShippingMethod(UpdateShippingMethodViewModel updateShippingMethod)
        {
            var procedureName = Constant.spUpdateShippingmethod;
            var parameters = new DynamicParameters();
            parameters.Add("@shippingMethodId", updateShippingMethod.shippingMethodId, DbType.Guid);
            parameters.Add("@name", updateShippingMethod.name, DbType.String);
            parameters.Add("@courier", updateShippingMethod.courier, DbType.String);
            parameters.Add("@shippingZone", updateShippingMethod.shippingZone, DbType.String);
            parameters.Add("@baseCost", updateShippingMethod.baseCost, DbType.String);
            parameters.Add("@costPerKg", updateShippingMethod.costPerKg, DbType.String);
            parameters.Add("@maxWeightLimit", updateShippingMethod.maxWeightLimit, DbType.String);
            parameters.Add("@minOrderValue", updateShippingMethod.minOrderValue, DbType.String);
            parameters.Add("@trackingURL", updateShippingMethod.trackingURL, DbType.String);
            parameters.Add("@updatedBy", updateShippingMethod.updatedBy, DbType.Guid);
            parameters.Add("@active", updateShippingMethod.active ? 1 : 0, DbType.Boolean);

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
        public async Task<ResponseViewModel> deleteShippingMethod(DeleteShippingMethodViewModel deleteShippingMethod)
        {
            var procedureName = Constant.spDeleteShippingMethod;
            var parameters = new DynamicParameters();
            parameters.Add("@shippingMethodId", deleteShippingMethod.shippingMethodId, DbType.Guid);
            parameters.Add("@updatedBy", deleteShippingMethod.updatedBy, DbType.Guid);
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

        public async Task<ResponseViewModel> getAllPinCodeshippingMethod()
        {
            var procedureName = Constant.spGetAllPinCodeshipping;

            using (var connection = _dapperContext.createConnection())
            {
                try
                {
                    var result = await connection.QueryAsync<PinCodeshippingMethod>(
                        procedureName,
                        commandType: CommandType.StoredProcedure
                    );

                    if (result == null || !result.Any())
                    {
                        return new ResponseViewModel
                        {
                            statusCode = (int)HttpStatusCode.NotFound,
                            message = "Data Not Found",
                            data = null
                        };
                    }

                    return new ResponseViewModel
                    {
                        statusCode = (int)HttpStatusCode.OK,
                        message = "Pin CodeShipping Data Found",
                        data = result
                    };
                }
                catch (SqlException sqlEx)
                {
                    return new ResponseViewModel
                    {
                        statusCode = (int)HttpStatusCode.InternalServerError,
                        message = $"SQL Error: {sqlEx.Message}",
                        data = null
                    };
                }
                catch (Exception ex)
                {
                    return new ResponseViewModel
                    {
                        statusCode = (int)HttpStatusCode.InternalServerError,
                        message = $"Error: {ex.Message}",
                        data = null
                    };
                }
            }
        }



        public async Task<ResponseViewModel> addPinCodeshippingMethod(AddPinCodeShippingViewModel addPinCodeshippingMethod)
        {
            var procedureName = Constant.spAddPinCodeshipping;
            var parameters = new DynamicParameters();
            parameters.Add("@pinCode", addPinCodeshippingMethod.pincode, DbType.Int64);
            parameters.Add("@shippingMethodId", addPinCodeshippingMethod.shippingMethodId, DbType.Guid); ;
            parameters.Add("@createdBy", addPinCodeshippingMethod.createdBy, DbType.Guid);
            parameters.Add("@noOfDays", addPinCodeshippingMethod.noOfDays, DbType.Int64);
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

        public async Task<ResponseViewModel> updatePinCodeShippingMethod(UpdatePinCodeShippingViewModel updatePinCodeShippingMethod)
        {
            var procedureName = Constant.spUpdatePinCodeshipping;
            var parameters = new DynamicParameters();
            parameters.Add("@pinCodeShippingId", updatePinCodeShippingMethod.pinCodeShippingId, DbType.Guid);
            parameters.Add("@pinCode", updatePinCodeShippingMethod.pincode, DbType.String);
            parameters.Add("@updatedBy", updatePinCodeShippingMethod.updatedBy, DbType.Guid);
            parameters.Add("@active", updatePinCodeShippingMethod.active ? 1 : 0, DbType.Boolean);
            parameters.Add("@noOfDays", updatePinCodeShippingMethod.noOfDays, DbType.Int64);


            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                    if (result != null)
                    {
                        result.statusCode = result.statusCode == 1 ? (int)HttpStatusCode.OK : (int)HttpStatusCode.ExpectationFailed;
                    }
                    else
                    {
                        return new ResponseViewModel
                        {
                            statusCode = (int)HttpStatusCode.InternalServerError,
                            message = "No response from stored procedure"
                        };
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                return new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = $"An error occurred: {ex.Message}"
                };
            }
        }

        public async Task<ResponseViewModel> deletePinCodeShippingMethod(DeletePinCodeShippingViewModel deletePinCodeShippingMethod)
        {
            var procedureName = Constant.spDeletePinCodeshipping;
            var parameters = new DynamicParameters();
            parameters.Add("@pinCodeShippingId", deletePinCodeShippingMethod.pinCodeShippingId, DbType.Guid);
            parameters.Add("@updatedBy", deletePinCodeShippingMethod.updatedBy, DbType.Guid);
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
        public async Task<ResponseViewModel> getAllPinCode(int pinCode)
        {
            var procedureName = Constant.spgetAllPinCodeActive;
            var parameters = new DynamicParameters();
            parameters.Add("@pinCode", pinCode, DbType.Int64);

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<PinCodeActive>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                    var getAllPinCode = new ResponseViewModel
                    {
                        statusCode = result.Any() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound,
                        message = result.Any() ? "Data Found" : "Data Not Found",
                        data = result
                    };

                    return getAllPinCode;
                }
            }
            catch (Exception ex)
            {
                return new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = "An error occurred: " + ex.Message,
                    data = null
                };
            }
        }

        //public async Task<ResponseViewModel> getAllPinCode(int pinCode)
        //{
        //    var procedureName = Constant.spGetByIdShipping;
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@pinCode", pinCode, DbType.Int64);
        //    using (var connection = _dapperContext.createConnection())
        //    {
        //        var result = await connection.QueryAsync<PinCodeActive>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        //        var getAllPinCode = new ResponseViewModel
        //        {
        //            statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
        //            message = result.Count() == 0 ? "Data Not Found" : "Data Found",
        //            data = result
        //        };
        //        return getAllPinCode;
        //    }
        //}
    }
}
