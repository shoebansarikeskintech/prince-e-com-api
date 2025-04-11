using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using static Model.ModelType;
using ViewModel;
using Common;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DapperContext _dapperContext;
        public CategoryRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;
        public async Task<ResponseViewModel> getByIdCategory(Guid categoryId)
        {
            var procedureName = Constant.spGetByIdCategory;
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", categoryId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Category>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getbyIdCategory = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getbyIdCategory;
            }
        }
        public async Task<ResponseViewModel> getAllCategory()
        {
            var procedureName = Constant.spGetAllCategory;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Category>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllCategory = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllCategory;
            }
        }
        public async Task<ResponseViewModel> getAllCategoryForUser()
        {
            var procedureName = Constant.spGetAllCategoryForUser;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Category>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllCategory = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllCategory;
            }
        }
        public async Task<ResponseViewModel> addCategory(AddCategoryViewModel addCategory)
        {

            string imagePath = "NaN";
            if (addCategory.image != null && addCategory.image.Length > 0)
            {
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(addCategory.image.FileName);
                string uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CategoryImage");
                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }
                string filePath = Path.Combine(uploadDir, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await addCategory.image.CopyToAsync(fileStream);
                }

                imagePath = uniqueFileName;
            }

            var procedureName = Constant.spAddCategory;
            var parameters = new DynamicParameters();
            parameters.Add("@name", addCategory.name, DbType.String);
            parameters.Add("@image", imagePath, DbType.String);
            parameters.Add("@createdBy", addCategory.createdBy, DbType.Guid);

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

        public async Task<ResponseViewModel> updateCategory(UpdateCategoryViewModel updateCategory)
        {

            string imagePath = null;
            if (updateCategory.image != null && updateCategory.image.Length > 0)
            {
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(updateCategory.image.FileName);
                string uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CategoryImage");
                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }
                string filePath = Path.Combine(uploadDir, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await updateCategory.image.CopyToAsync(fileStream);
                }

                imagePath = uniqueFileName;
            }
            var procedureName = Constant.spUpdateCategory;
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", updateCategory.categoryId, DbType.Guid);
            parameters.Add("@name", updateCategory.name, DbType.String);
            parameters.Add("@active", updateCategory.active ? 1 : 0, DbType.Boolean);
            parameters.Add("@image", imagePath, DbType.String);
            parameters.Add("@updatedBy", updateCategory.updatedBy, DbType.Guid);
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
        public async Task<ResponseViewModel> deleteCategory(DeleteCategoryViewModel deleteCategory)
        {
            var procedureName = Constant.spDeleteCategory;
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", deleteCategory.categoryId, DbType.Guid);
            parameters.Add("@updatedBy", deleteCategory.updatedBy, DbType.Guid);
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
