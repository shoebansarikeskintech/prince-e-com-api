using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using ViewModel;
using Common;
using static Model.ModelType;

namespace Repository
{
   public class BannerRepository : IBannerRepository
    {
        private readonly DapperContext _dapperContext;
        public BannerRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;
        public async Task<ResponseViewModel> getByIdBanner(Guid bannerId)
        {
            var procedureName = Constant.spGetByIdBanner;
            var parameters = new DynamicParameters();
            parameters.Add("@bannerId", bannerId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Banner>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getbyIdSubCategory = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getbyIdSubCategory;
            }
        }
        public async Task<ResponseViewModel> getAllBanner()
        {
            var procedureName = Constant.spGetAllBanner;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Banner>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllBanner = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllBanner;
            }
        }
        public async Task<ResponseViewModel> addBanner(AddBannerViewModel addBanner)
        {
            string imagePath = "NaN";
            if (addBanner.image != null && addBanner.image.Length > 0)
            {
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(addBanner.image.FileName);
                string uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BannerImage");
                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }
                string filePath = Path.Combine(uploadDir, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await addBanner.image.CopyToAsync(fileStream);
                }
                imagePath = uniqueFileName;
            }

            var procedureName = Constant.spAddBanner;
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", addBanner.categoryId, DbType.Guid);
            parameters.Add("@subCategoryId", addBanner.subCategoryId, DbType.Guid);
            parameters.Add("@subCategoryTypeId", addBanner.subCategoryTypeId, DbType.Guid);
            parameters.Add("@image", imagePath, DbType.String);
            parameters.Add("@title", addBanner.title, DbType.String);
            parameters.Add("@subTitle", addBanner.subTitle, DbType.String);
            parameters.Add("@createdBy", addBanner.createdBy, DbType.Guid);
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
        public async Task<ResponseViewModel> updateBanner(UpdateBannerViewModel updateBanner)
        {
            //string imagePath = "NaN";
            string imagePath = null;
            if (updateBanner.image != null && updateBanner.image.Length > 0)
            {
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(updateBanner.image.FileName);
                string uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BannerImage");
                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }
                string filePath = Path.Combine(uploadDir, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await updateBanner.image.CopyToAsync(fileStream);
                }
                imagePath = uniqueFileName;
            }

            var procedureName = Constant.spUpdateBanner;

            var parameters = new DynamicParameters();
            parameters.Add("@bannerId", updateBanner.bannerId, DbType.Guid);
            parameters.Add("@subCategoryId", updateBanner.subCategoryId, DbType.Guid);
            parameters.Add("@image", imagePath, DbType.String);
            parameters.Add("@title", updateBanner.title, DbType.String);
            parameters.Add("@subTitle", updateBanner.subTitle, DbType.String);
            parameters.Add("@active", updateBanner.active ? 1 : 0, DbType.Boolean);
            parameters.Add("@updatedBy", updateBanner.updatedBy, DbType.Guid);
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
        public async Task<ResponseViewModel> deleteBanner(DeleteBannerViewModel deleteBanner)
        {
            var procedureName = Constant.spDeleteBanner;
            var parameters = new DynamicParameters();
            parameters.Add("@bannerId", deleteBanner.bannerId, DbType.Guid);
            parameters.Add("@updatedBy", deleteBanner.updatedBy, DbType.Guid);
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
