
using Dapper;
using RepositoryContract;
using static Model.ModelType;
using System.Data;
using System.Net;
using ViewModel;
using Common;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ResponseViewModel> getAllCategoriesNew()
        {
            var procedureCategory = Constant.spGetAllCategoryForUser;
            var procedureSubCategory = Constant.spGetAllSubCategoryForUser;
            var procedureSubCategoryType = Constant.spGetAllSubCategoryTypeForUser;

            var procedureBestSeller = Constant.spGetBestSeller;
            var procedureBestRecommended = Constant.spGetisRecommended;
            var procedureBestArrial = Constant.spGetIsNewArrial;

            using (var connection = _dapperContext.createConnection())
            {
                var resultCategory = await connection.QueryAsync<Category>(procedureCategory, commandType: CommandType.StoredProcedure);
                var resultSubCategory = await connection.QueryAsync<SubCategory>(procedureSubCategory, commandType: CommandType.StoredProcedure);
                var resultSubCategoryType = await connection.QueryAsync<SubCategoryType>(procedureSubCategoryType, commandType: CommandType.StoredProcedure);
                var subCategoryLookup = resultSubCategory.ToLookup(subCat => subCat.categoryId);
                var subCategoryTypeLookup = resultSubCategoryType.ToLookup(subCatType => subCatType.subCategoryId);

                // Fetch full data for bestSeller, bestRecommended, and bestArrial
                var bestSeller = await connection.QueryAsync<Product>(procedureBestSeller, commandType: CommandType.StoredProcedure);
                var bestRecommended = await connection.QueryAsync<Product>(procedureBestRecommended, commandType: CommandType.StoredProcedure);
                var bestArrial = await connection.QueryAsync<Product>(procedureBestArrial, commandType: CommandType.StoredProcedure);

                // Creating the response structure with separate lists for bestSeller, bestRecommended, and bestArrial
                var response = new ResponseViewModel
                {
                    statusCode = 200,
                    message = "Data Found",
                    data = new
                    {
                        menu = resultCategory.Select(category => new
                        {
                            categoryId = category.categoryId,
                            id = category.Id,
                            name = category.name,
                            image = category.image,
                            subCategory = subCategoryLookup[category.categoryId].Select(subCat => new
                            {
                                id = category.Id,
                                categoryId = subCat.categoryId,
                                categoryName = subCat.categoryName,
                                subCategoryId = subCat.subCategoryId,
                                name = subCat.name,
                                subCategoryType = subCategoryTypeLookup[subCat.subCategoryId].Select(subCatType => new
                                {
                                    id = category.Id,
                                    categoryId = subCatType.categoryId,
                                    subCategoryId = subCatType.subCategoryId,
                                    subCategoryTypeId = subCatType.subCategoryTypeId,
                                    name = subCatType.name
                                }).ToList()
                            }).ToList()
                        }).ToList(),
                        bestSeller = bestSeller, // All bestSeller products data
                        bestRecommended = bestRecommended, // All bestRecommended products data
                        bestArrial = bestArrial // All bestArrial products data
                    }
                };

                return response;
            }
        }

        //public async Task<ResponseViewModel> getAllCategoriesNew()
        //{
        //    var procedureCategory = Constant.spGetAllCategoryForUser;
        //    var procedureSubCategory = Constant.spGetAllSubCategoryForUser;
        //    var procedureSubCategoryType = Constant.spGetAllSubCategoryTypeForUser;

        //    var procedureBestSeller = Constant.spGetBestSeller;
        //    var procedureBestRecommended = Constant.spGetisRecommended;
        //    var procedureBestArrial = Constant.spGetIsNewArrial;

        //    using (var connection = _dapperContext.createConnection())
        //    {
        //        var resultCategory = await connection.QueryAsync<Category>(procedureCategory, commandType: CommandType.StoredProcedure);
        //        var resultSubCategory = await connection.QueryAsync<SubCategory>(procedureSubCategory, commandType: CommandType.StoredProcedure);
        //        var resultSubCategoryType = await connection.QueryAsync<SubCategoryType>(procedureSubCategoryType, commandType: CommandType.StoredProcedure);
        //        var subCategoryLookup = resultSubCategory.ToLookup(subCat => subCat.categoryId);
        //        var subCategoryTypeLookup = resultSubCategoryType.ToLookup(subCatType => subCatType.subCategoryId);

        //        // Fetch full data for bestSeller, bestRecommended, and bestArrial
        //        var bestSeller = await connection.QueryAsync<Product>(procedureBestSeller, commandType: CommandType.StoredProcedure);
        //        var bestRecommended = await connection.QueryAsync<Product>(procedureBestRecommended, commandType: CommandType.StoredProcedure);
        //        var bestArrial = await connection.QueryAsync<Product>(procedureBestArrial, commandType: CommandType.StoredProcedure);

        //        // Creating the response structure
        //        var response = new ResponseViewModel
        //        {
        //            statusCode = 200,
        //            message = "Data Found",
        //            data = new
        //            {
        //                menu = resultCategory.Select(category => new
        //                {
        //                    categoryId = category.categoryId,
        //                    name = category.name,
        //                    image = category.image,
        //                    subCategory = subCategoryLookup[category.categoryId].Select(subCat => new
        //                    {
        //                        categoryId = subCat.categoryId,
        //                        categoryName = subCat.categoryName,
        //                        subCategoryId = subCat.subCategoryId,
        //                        name = subCat.name,
        //                        subCategoryType = subCategoryTypeLookup[subCat.subCategoryId].Select(subCatType => new
        //                        {
        //                            categoryId = subCatType.categoryId,
        //                            subCategoryId = subCatType.subCategoryId,
        //                            subCategoryTypeId = subCatType.subCategoryTypeId,
        //                            name = subCatType.name
        //                        }).ToList()
        //                    }).ToList()
        //                }).ToList(),
        //                bestSeller = bestSeller, // All bestSeller products data
        //                bestRecommended = bestRecommended, // All bestRecommended products data
        //                bestArrial = bestArrial // All bestArrial products data
        //            }
        //        };

        //        return response;
        //    }
        //}

        //public async Task<ResponseViewModel> getAllCategoriesNew()
        //{
        //    var procedureCategory = Constant.spGetAllCategoryForUser;
        //    var procedureSubCategory = Constant.spGetAllSubCategoryForUser;
        //    var procedureSubCategoryType = Constant.spGetAllSubCategoryTypeForUser;

        //    var procedureBestSeller = Constant.spGetBestSeller;
        //    var procedureBestRecommended = Constant.spGetisRecommended;
        //    var procedureBestArrial = Constant.spGetIsNewArrial;

        //    using (var connection = _dapperContext.createConnection())
        //    {
        //        var resultCategory = await connection.QueryAsync<Category>(procedureCategory, commandType: CommandType.StoredProcedure);
        //        var resultSubCategory = await connection.QueryAsync<SubCategory>(procedureSubCategory, commandType: CommandType.StoredProcedure);
        //        var resultSubCategoryType = await connection.QueryAsync<SubCategoryType>(procedureSubCategoryType, commandType: CommandType.StoredProcedure);
        //        var subCategoryLookup = resultSubCategory.ToLookup(subCat => subCat.categoryId);
        //        var subCategoryTypeLookup = resultSubCategoryType.ToLookup(subCatType => subCatType.subCategoryId);

        //        // Fetch full data for bestSeller, bestRecommended, and bestArrial
        //        var bestSeller = await connection.QueryAsync<Product>(procedureBestSeller, commandType: CommandType.StoredProcedure);
        //        var bestRecommended = await connection.QueryAsync<Product>(procedureBestRecommended, commandType: CommandType.StoredProcedure);
        //        var bestArrial = await connection.QueryAsync<Product>(procedureBestArrial, commandType: CommandType.StoredProcedure);

        //        // Creating the response list
        //        var list = resultCategory.Select(category => new
        //        {
        //            categoryId = category.categoryId,
        //            name = category.name,
        //            image = category.image,
        //            subCategory = subCategoryLookup[category.categoryId].Select(subCat => new
        //            {
        //                categoryId = subCat.categoryId,
        //                categoryName = subCat.categoryName,
        //                subCategoryId = subCat.subCategoryId,
        //                name = subCat.name,
        //                subCategoryType = subCategoryTypeLookup[subCat.subCategoryId].Select(subCatType => new
        //                {
        //                    categoryId = subCatType.categoryId,
        //                    subCategoryId = subCatType.subCategoryId,
        //                    subCategoryTypeId = subCatType.subCategoryTypeId,
        //                    name = subCatType.name
        //                }).ToList()
        //            }).ToList(),
        //            bestSeller = bestSeller, // Add the bestSeller data to the response
        //            bestRecommended = bestRecommended, // Add the bestRecommended data to the response
        //            bestArrial = bestArrial // Add the bestArrial data to the response
        //        }).ToList();

        //        // Preparing the response
        //        var response = new ResponseViewModel
        //        {
        //            statusCode = list.Any() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound,
        //            message = list.Any() ? "Data Found" : "Data Not Found",
        //            data = list
        //        };

        //        return response;
        //    }
        //}

        //public async Task<ResponseViewModel> getAllCategoriesNew()
        //{
        //    var procedureCategory = Constant.spGetAllCategoryForUser;
        //    var procedureSubCategory = Constant.spGetAllSubCategoryForUser;
        //    var procedureSubCategoryType = Constant.spGetAllSubCategoryTypeForUser;

        //    var procedureBestSeller = Constant.spGetBestSeller;
        //    var procedureBestRecommended = Constant.spGetisRecommended;
        //    var procedureBestArrial = Constant.spGetIsNewArrial;

        //    using (var connection = _dapperContext.createConnection())
        //    {
        //        var resultCategory = await connection.QueryAsync<Category>(procedureCategory, commandType: CommandType.StoredProcedure);
        //        var resultSubCategory = await connection.QueryAsync<SubCategory>(procedureSubCategory, commandType: CommandType.StoredProcedure);
        //        var resultSubCategoryType = await connection.QueryAsync<SubCategoryType>(procedureSubCategoryType, commandType: CommandType.StoredProcedure);
        //        var subCategoryLookup = resultSubCategory.ToLookup(subCat => subCat.categoryId);
        //        var subCategoryTypeLookup = resultSubCategoryType.ToLookup(subCatType => subCatType.subCategoryId);

        //        var bestSeller = await connection.QueryAsync<Product>(procedureBestSeller, commandType: CommandType.StoredProcedure);
        //        var bestRecommended = await connection.QueryAsync<Product>(procedureBestRecommended, commandType: CommandType.StoredProcedure);
        //        var bestArrial = await connection.QueryAsync<Product>(procedureBestArrial, commandType: CommandType.StoredProcedure);

        //        var list = resultCategory.Select(category => new
        //        {
        //            categoryId = category.categoryId,
        //            name = category.name,
        //            image = category.image,
        //            subCategory = subCategoryLookup[category.categoryId].Select(subCat => new
        //            {
        //                categoryId = subCat.categoryId,
        //                categoryName = subCat.categoryName,
        //                subCategoryId = subCat.subCategoryId,
        //                name = subCat.name,
        //                subCategoryType = subCategoryTypeLookup[subCat.subCategoryId].Select(subCatType => new
        //                {
        //                    categoryId = subCatType.categoryId,
        //                    subCategoryId = subCatType.subCategoryId,
        //                    subCategoryTypeId = subCatType.subCategoryTypeId,
        //                    name = subCatType.name
        //                }).ToList()
        //            }).ToList()
        //        }).ToList();



        //        var response = new ResponseViewModel
        //        {
        //            statusCode = list.Any() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound,
        //            message = list.Any() ? "Data Found" : "Data Not Found",
        //            data = new { menu = list } // Wrap the list in a 'menu' property
        //        };

        //        return response;
        //    }
        //}

        //public async Task<ResponseViewModel> getAllCategoriesNew()
        //{
        //    var procedureCategory = Constant.spGetAllCategoryForUser;
        //    var procedureSubCategory = Constant.spGetAllSubCategoryForUser;
        //    var procedureSubCategoryType = Constant.spGetAllSubCategoryTypeForUser;

        //    var procedureBestSeller = Constant.spGetBestSeller;
        //    var procedureBestRecommended = Constant.spGetisRecommended;
        //    var procedureBestArrial = Constant.spGetIsNewArrial;

        //    using (var connection = _dapperContext.createConnection())
        //    {
        //        var resultCategory = await connection.QueryAsync<Category>(procedureCategory, commandType: CommandType.StoredProcedure);
        //        var resultSubCategory = await connection.QueryAsync<SubCategory>(procedureSubCategory, commandType: CommandType.StoredProcedure);
        //        var resultSubCategoryType = await connection.QueryAsync<SubCategoryType>(procedureSubCategoryType, commandType: CommandType.StoredProcedure);
        //        var subCategoryLookup = resultSubCategory.ToLookup(subCat => subCat.categoryId);
        //        var subCategoryTypeLookup = resultSubCategoryType.ToLookup(subCatType => subCatType.subCategoryId);

        //        var bestSeller = await connection.QueryAsync<Product>(procedureBestSeller, commandType: CommandType.StoredProcedure);
        //        var bestRecommended = await connection.QueryAsync<Product>(procedureBestRecommended, commandType: CommandType.StoredProcedure);
        //        var bestArrial = await connection.QueryAsync<Product>(procedureBestArrial, commandType: CommandType.StoredProcedure);



        //        var list = resultCategory.Select(category => new
        //        {
        //            categoryId = category.categoryId,
        //            name = category.name,
        //            image = category.image,
        //            subCategory = subCategoryLookup[category.categoryId].Select(subCat => new
        //            {
        //                categoryId = subCat.categoryId,
        //                categoryName = subCat.categoryName,
        //                subCategoryId = subCat.subCategoryId,
        //                name = subCat.name,
        //                subCategoryType = subCategoryTypeLookup[subCat.subCategoryId].Select(subCatType => new
        //                {
        //                    categoryId = subCatType.categoryId,
        //                    subCategoryId = subCatType.subCategoryId,
        //                    subCategoryTypeId = subCatType.subCategoryTypeId,
        //                    name = subCatType.name
        //                }).ToList()
        //            }).ToList()
        //        }).ToList();

        //        var response = new ResponseViewModel
        //        {
        //            statusCode = list.Any() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound,
        //            message = list.Any() ? "Data Found" : "Data Not Found",
        //            data = list
        //        };

        //        return response;
        //    }
        //}
    }
}
