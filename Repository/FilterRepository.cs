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
        //public async Task<ResponseViewModel> getPrdoctSearchByFilter(FilterViewModel model)
        //{
        //    var procedureName = Constant.spGetPrdoctSearchByFilter;

        //    using (var connection = _dapperContext.createConnection())
        //    {
        //        DynamicParameters param = new DynamicParameters();
        //        param.Add("@categoryName", model.categoryName);
        //        param.Add("@subCategoryName", model.subCategoryName);
        //        param.Add("@productName", model.productName);
        //        param.Add("@sellerName", model.sellerName);
        //        param.Add("@brandName", model.brandName);
        //        param.Add("@sizeName", model.sizeName);
        //        param.Add("@concernName", model.concernName);
        //        param.Add("@ingredientName", model.ingredientName);
        //        var result = await connection.QueryAsync<PrdoctSearchByFilter>(procedureName, null, commandType: CommandType.StoredProcedure);
        //        var getPrdoctSearchByFilter = new ResponseViewModel
        //        {
        //            statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
        //            message = result.Count() == 0 ? "Data Not Found" : "Data Found",
        //            data = result
        //        };
        //        return getPrdoctSearchByFilter;
        //    }
        //}
        public async Task<ResponseViewModel> getProductSearchByFilter(FilterViewModel model)
        {
            var procedureName = Constant.spGetPrdoctSearchByFilter;

            using (var connection = _dapperContext.createConnection())
            {
                try
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@categoryName", model.categoryName ?? "");
                    param.Add("@subCategoryName", model.subCategoryName ?? "");
                    param.Add("@productName", model.productName ?? "");
                    param.Add("@sellerName", model.sellerName ?? "");
                    param.Add("@brandName", model.brandName ?? "");
                    param.Add("@sizeName", model.sizeName ?? "");
                    param.Add("@concernName", model.concernName ?? "");
                    param.Add("@ingredientName", model.ingredientName ?? "");

                    var result = await connection.QueryAsync<PrdoctSearchByFilter>(
                        procedureName, param, commandType: CommandType.StoredProcedure);

                    return new ResponseViewModel
                    {
                        statusCode = result.Any() ? 200 : 404,
                        message = result.Any() ? "Data Found" : "Data Not Found",
                        data = result
                    };
                }
                catch (Exception ex)
                {
                    return new ResponseViewModel
                    {
                        statusCode = 500,
                        message = "Error: " + ex.Message,
                        data = null
                    };
                }
            }
        }

     

    }
}
