using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using static Model.ModelType;
using ViewModel;
using Common;

namespace Repository
{

    public class FilterRepository : IFilterRepository
    {
        private readonly DapperContext _dapperContext;
        public FilterRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;

        public async Task<ResponseViewModel> getAllSortBy()
        {
            var procedureName = Constant.spGetSortBy;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<SortBy>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllSortBy = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllSortBy;
            }
        }

        public async Task<ResponseViewModel> getAllFilter()
        {
            var procedureSortBy = Constant.spGetSortBy;
            var procedureBrand = Constant.spGetAllBrandForUser;
            var procedureColor = Constant.spGetAllColorForUser;
            var procedureSize = Constant.spGetAllSizeForUser;

            using (var connection = _dapperContext.createConnection())
            {
                var sortByResult = await connection.QueryAsync<SortBy>(procedureSortBy, null, commandType: CommandType.StoredProcedure);
                var brandResult = await connection.QueryAsync<Brand>(procedureBrand, null, commandType: CommandType.StoredProcedure);
                var colorResult = await connection.QueryAsync<Color>(procedureColor, null, commandType: CommandType.StoredProcedure);
                var sizeResult = await connection.QueryAsync<SizeRes>(procedureSize, null, commandType: CommandType.StoredProcedure);

                var response = new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.OK,
                    message = "Data Found",
                    data = new
                    {
                        SortBy = sortByResult,
                        Brand = brandResult,
                        Color = colorResult,
                        Size = sizeResult
                    }
                };

                if (sortByResult.Count() == 0 && brandResult.Count() == 0 && colorResult.Count() == 0 && sizeResult.Count() == 0)
                {
                    response.statusCode = (int)HttpStatusCode.NotFound;
                    response.message = "Data Not Found";
                }
                return response;
            }
        }
    }
}
