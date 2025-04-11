using Common;
using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using ViewModel;
using static Model.ModelType;

namespace Repository
{
    public class ColorRepository: IColorRepository
    {
        private readonly DapperContext _dapperContext;
        public ColorRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;
        public async Task<ResponseViewModel> getByIdColor(Guid colorId)
        {
            var procedureName = Constant.spGetByIdColor;
            var parameters = new DynamicParameters();
            parameters.Add("@colorId", colorId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Color>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getbyIdColor = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getbyIdColor;
            }
        }
        public async Task<ResponseViewModel> getAllColor()
        {
            var procedureName = Constant.spGetAllColor;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Color>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllColor = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllColor;
            }
        }

        public async Task<ResponseViewModel> getAllColorForUser()
        {
            var procedureName = Constant.spGetAllColorForUser;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Color>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllColor = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllColor;
            }
        }
        public async Task<ResponseViewModel> addColor(AddColorViewModel addColor)
        {
            string colorCode = Utils.findColorCode(addColor.name);

            var procedureName = Constant.spAddColor;
            var parameters = new DynamicParameters();
            parameters.Add("@name", System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(addColor.name), DbType.String);
            parameters.Add("@code", colorCode, DbType.String);
            parameters.Add("@createdBy", addColor.createdBy, DbType.Guid);
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
        public async Task<ResponseViewModel> updateColor(UpdateColorViewModel updateColor)
        {
            string colorCode = Utils.findColorCode(updateColor.name);
            var procedureName = Constant.spUpdateColor;
            var parameters = new DynamicParameters();
            parameters.Add("@colorId", updateColor.colorId, DbType.Guid);
            parameters.Add("@name", System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(updateColor.name), DbType.String);
            parameters.Add("@code", colorCode, DbType.String);
            parameters.Add("@active", updateColor.active ? 1 : 0, DbType.Boolean);
            parameters.Add("@updatedBy", updateColor.updatedBy, DbType.Guid);
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
        public async Task<ResponseViewModel> deleteColor(DeleteColorViewModel deleteColor)
        {
            var procedureName = Constant.spDeleteColor;
            var parameters = new DynamicParameters();
            parameters.Add("@colorId", deleteColor.colorId, DbType.Guid);
            parameters.Add("@updatedBy", deleteColor.updatedBy, DbType.Guid);
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

