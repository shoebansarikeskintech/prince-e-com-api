
using Dapper;
using RepositoryContract;
using static Model.ModelType;
using System.Data;
using System.Net;
using ViewModel;
using Common;

namespace Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly DapperContext _dapperContext;
        public DashboardRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;

        public async Task<ResponseViewModel> getAllBannerForUser()
        {
            var procedureName = Constant.spGetAllBannerForUser;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<BannerForUser>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllBannerForUser = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllBannerForUser;
            }
        }

        public async Task<ResponseViewModel> getAllCategories()
        {
            var procedureCategory = Constant.spGetAllCategoryForUser;
            var procedureSubCategory = Constant.spGetAllSubCategoryForUser;
            var procedureSubCategoryType = Constant.spGetAllSubCategoryTypeForUser;

            using (var connection = _dapperContext.createConnection())
            {
                var resultCategory = await connection.QueryAsync<Category>(procedureCategory, commandType: CommandType.StoredProcedure);
                var resultSubCategory = await connection.QueryAsync<SubCategory>(procedureSubCategory, commandType: CommandType.StoredProcedure);
                var resultSubCategoryType = await connection.QueryAsync<SubCategoryType>(procedureSubCategoryType, commandType: CommandType.StoredProcedure);

                var subCategoryLookup = resultSubCategory.ToLookup(subCat => subCat.categoryId);
                var subCategoryTypeLookup = resultSubCategoryType.ToLookup(subCatType => subCatType.subCategoryId);

                var list = resultCategory.Select(category => new
                {
                    categoryId = category.categoryId,
                    name = category.name,
                    image = category.image,
                    subCategory = subCategoryLookup[category.categoryId].Select(subCat => new
                    {
                        categoryId = subCat.categoryId,
                        categoryName = subCat.categoryName,
                        subCategoryId = subCat.subCategoryId,
                        name = subCat.name,
                        subCategoryType = subCategoryTypeLookup[subCat.subCategoryId].Select(subCatType => new
                        {
                            categoryId = subCatType.categoryId,
                            subCategoryId = subCatType.subCategoryId,
                            subCategoryTypeId = subCatType.subCategoryTypeId,
                            name = subCatType.name
                        }).ToList()
                    }).ToList()
                }).ToList();

                var response = new ResponseViewModel
                {
                    statusCode = list.Any() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound,
                    message = list.Any() ? "Data Found" : "Data Not Found",
                    data = list
                };

                return response;
            }
        }

        public async Task<ResponseViewModel> getShopByCategory()
        {
            var procedureName = Constant.spGetAllCategoryForUser;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Category>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getShopByCategory = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getShopByCategory;
            }
        }
    }
}
