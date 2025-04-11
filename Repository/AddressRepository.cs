using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using static Model.ModelType;
using ViewModel;
using Common;

namespace Repository
{
  public  class AddressRepository : IAddressRepository
    {
        private readonly DapperContext _dapperContext;
        public AddressRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;
        public async Task<ResponseViewModel> getDefaultAddress(Guid userId)
        {
            var procedureName = Constant.spGetDefaultAddress;
            var parameters = new DynamicParameters();
            parameters.Add("@userId", userId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Address>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var GetDefaultAddress = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Default Address Data Found",
                    data = result
                };
                return GetDefaultAddress;
            }
        }
        public async Task<ResponseViewModel> getAddressList(Guid userId)
        {
            var response = new ResponseViewModel();
            try
            {
                var procedureName = Constant.spGetAddressList;
                var parameters = new DynamicParameters();
                parameters.Add("@userId", userId, DbType.Guid);

                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<Address>(
                        procedureName, parameters, commandType: CommandType.StoredProcedure
                    );

                    response.statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK;
                    response.message = result.Count() == 0 ? "Data Not Found" : "Address Data Found";
                    response.data = result;
                }
            }
            catch (Exception ex)
            {
                response.statusCode = (int)HttpStatusCode.InternalServerError;
                response.message = $"Something went wrong: {ex.Message}";
                response.data = null;
            }

            return response;
        }
      
        public async Task<ResponseViewModel> addAddress(AddAddressViewModel addAddress)
        {
            var procedureName = Constant.spAddAddress;
            var parameters = new DynamicParameters();
            parameters.Add("@userId", addAddress.userId, DbType.Guid);
            parameters.Add("@isDefualt", addAddress.isDefualt ? 1 : 0, DbType.Boolean);
            parameters.Add("@name", addAddress.name, DbType.String);
            parameters.Add("@mobile", addAddress.mobile, DbType.String);
            parameters.Add("@email", addAddress.email, DbType.String);
            parameters.Add("@streetAddress", addAddress.streetAddress, DbType.String);
            parameters.Add("@state", addAddress.state, DbType.String);
            parameters.Add("@city", addAddress.city, DbType.String);
            parameters.Add("@pincode", addAddress.pincode, DbType.String);
            parameters.Add("@country", addAddress.country, DbType.String);
            parameters.Add("@createdBy", addAddress.createdBy, DbType.Guid);

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
        public async Task<ResponseViewModel> updateAddress(UpdateAddressViewModel updateAddress)
        {
            var procedureName = Constant.spUpdateAddress;
            var parameters = new DynamicParameters();
            parameters.Add("@userId", updateAddress.userId, DbType.Guid);
            parameters.Add("@addressId", updateAddress.addressId, DbType.Guid);
            parameters.Add("@isDefualt", updateAddress.isDefualt ? 1 : 0, DbType.Boolean);
            parameters.Add("@name", updateAddress.name, DbType.String);
            parameters.Add("@mobile", updateAddress.mobile, DbType.String);
            parameters.Add("@email", updateAddress.email, DbType.String);
            parameters.Add("@streetAddress", updateAddress.streetAddress, DbType.String);
            parameters.Add("@state", updateAddress.state, DbType.String);
            parameters.Add("@city", updateAddress.city, DbType.String);
            parameters.Add("@pincode", updateAddress.pincode, DbType.String);
            parameters.Add("@country", updateAddress.country, DbType.String);
            parameters.Add("@updatedBy", updateAddress.updatedBy, DbType.Guid);
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
        public async Task<ResponseViewModel> deleteAddress(DeleteAddressViewModel deleteAddress)
        {
            var procedureName = Constant.spDeleteAddress;
            var parameters = new DynamicParameters();
            parameters.Add("@userId", deleteAddress.userId, DbType.Guid);
            parameters.Add("@addressId", deleteAddress.addressId, DbType.Guid);
            parameters.Add("@updatedBy", deleteAddress.updatedBy, DbType.Guid);
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
