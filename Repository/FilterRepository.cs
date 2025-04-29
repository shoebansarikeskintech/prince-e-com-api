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
        public async Task<ResponseViewModel> getProductSearchByFilter(FilterViewModel model)
        {
            var procedureName = Constant.spGetProductSearchByFilter;

            using (var connection = _dapperContext.createConnection())
            {
                try
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@categoryName", model.categoryName ?? "");
                    param.Add("@subCategoryName", model.subCategoryName ?? "");
                    param.Add("@subcategoryTypeName", model.subcategoryTypeName ?? "");
                    param.Add("@productName", model.productName ?? "");
                    param.Add("@sellerName", model.sellerName ?? "");
                    param.Add("@stepsName", model.stepsName ?? "");
                    param.Add("@typeofProductName", model.typeofProductName ?? "");
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
        public async Task<ResponseViewModel> getProductSearchByFilterNew(FilterViewModelNew model)
        {
            var procedureName = Constant.spGetProductSearchByFilterNew;

            using (var connection = _dapperContext.createConnection())
            {
                try
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@categoryIds", model.categoryIds ?? "");
                    param.Add("@subCategoryIds", model.subCategoryIds ?? "");
                    param.Add("@subcategoryTypeIds", model.subcategoryTypeIds ?? "");
                    param.Add("@productIds", model.productIds ?? "");
                    param.Add("@sellerIds", model.sellerIds ?? "");
                    param.Add("@stepsIds", model.stepsIds ?? "");
                    param.Add("@typeofProductIds", model.typeofProductIds ?? "");
                    param.Add("@sizeIds", model.sizeIds ?? "");
                    param.Add("@concernIds", model.concernIds ?? "");
                    param.Add("@ingredientIds", model.ingredientIds ?? "");

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

        public async Task<ResponseViewModel> getAllSkinInsightProduct()
        {
            var procedureName = Constant.spGetAllSkinInsightProduct;

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<AllSkinInsightProduct>(
                        procedureName,
                        null,
                        commandType: CommandType.StoredProcedure
                    );

                    var getAllSortBy = new ResponseViewModel
                    {
                        statusCode = result.Any() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound,
                        message = result.Any() ? "Data Found" : "Data Not Found",
                        data = result
                    };

                    return getAllSortBy;
                }
            }
            catch (Exception ex)
            {
                // (Optional) Log the error here if needed
                return new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = "An error occurred while fetching Skin Insight Products: " + ex.Message,
                    data = null
                };
            }
        }


    }
}
