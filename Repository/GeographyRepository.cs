using Dapper;
using RepositoryContract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Model.ModelType;
using ViewModel;
using Common;

namespace Repository
{
    public class GeographyRepository: IGeographyRepository
    {
        private readonly DapperContext _dapperContext;
        public GeographyRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;
        public async Task<ResponseViewModel> getAllCountryMethod()
        {
            var procedureName = Constant.spGetAllCountry;
            var parameters = new DynamicParameters();

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<CountryMethod>(procedureName, null, commandType: CommandType.StoredProcedure);

                    return new ResponseViewModel
                    {
                        statusCode = result.Any() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound,
                        message = result.Any() ? "Country List Data Found" : "Data Not Found",
                        data = result
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = "An error occurred while fetching country data.",
                    // errorDetails = ex.Message // Optional: add for debugging/logging
                };
            }
        }



        public async Task<ResponseViewModel> getAllStateMethod(int Fk_CountryId)
        {
            var procedureName = Constant.spGetAllState;
            var parameters = new DynamicParameters();
            parameters.Add("@Fk_CountryId", Fk_CountryId, DbType.Int32);

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<StateMethod>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                    return new ResponseViewModel
                    {
                        statusCode = result.Any() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound,
                        message = result.Any() ? "Data Found" : "Data Not Found",
                        data = result
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = "An error occurred while fetching state data.",
                    //errorDetails = ex.Message // Optional for debugging/logging
                };
            }
        }
        public async Task<ResponseViewModel> getAllCityMethod(int Fk_StateId)
        {
            var procedureName = Constant.spGetAllCity;
            var parameters = new DynamicParameters();
            parameters.Add("@Fk_StateId", Fk_StateId, DbType.Int32);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<City>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getbyCity = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getbyCity;
            }
        }
    }
}
