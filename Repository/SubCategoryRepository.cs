using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using static Model.ModelType;
using ViewModel;
using Common;

namespace Repository
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly DapperContext _dapperContext;
        public SubCategoryRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;
        public async Task<ResponseViewModel> getByIdSubCategory(Guid subCategoryId)
        {
            var procedureName = Constant.spGetByIdSubCategory;
            var parameters = new DynamicParameters();
            parameters.Add("@subCategoryId", subCategoryId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<SubCategory>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getbyIdSubCategory = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getbyIdSubCategory;
            }
        }

        public async Task<ResponseViewModel> getAllSubCategory()
        {
            var procedureName = Constant.spGetAllSubCategory;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<SubCategory>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllSubCategory = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllSubCategory;
            }
        }

        public async Task<ResponseViewModel> getAllSubCategoryForUser()
        {
            var procedureName = Constant.spGetAllSubCategoryForUser;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<SubCategory>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllSubCategory = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllSubCategory;
            }
        }

        public async Task<ResponseViewModel> addSubCategory(AddSubCategoryViewModel addSubCategory)
        {
            var procedureName = Constant.spAddSubCategory;
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId",addSubCategory.categoryId, DbType.Guid);
            parameters.Add("@name", addSubCategory.name, DbType.String);
            parameters.Add("@createdBy", addSubCategory.createdBy, DbType.Guid);

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
        public async Task<ResponseViewModel> updateSubCategory(UpdateSubCategoryViewModel updateSubCategory)
        {
            var procedureName = Constant.spUpdateSubCategory;

            var parameters = new DynamicParameters();
            parameters.Add("@subCategoryId", updateSubCategory.subCategoryId, DbType.Guid);
            parameters.Add("@name", updateSubCategory.name, DbType.String);
            parameters.Add("@active", updateSubCategory.active ? 1 : 0, DbType.Boolean);
            parameters.Add("@updatedBy", updateSubCategory.updatedBy, DbType.Guid);
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
        public async Task<ResponseViewModel> deleteSubCategory(DeleteSubCategoryViewModel deleteSubCategory)
        {
            var procedureName = Constant.spDeleteSubCategory;
            var parameters = new DynamicParameters();
            parameters.Add("@subCategoryId", deleteSubCategory.subCategoryId, DbType.Guid);
            parameters.Add("@updatedBy", deleteSubCategory.updatedBy, DbType.Guid);
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
