using Common;
using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using ViewModel;
using static Model.ModelType;

namespace Repository
{
    public class AppRoleRepository : IAppRoleRepository
    {
        private readonly DapperContext _dapperContext;
        public AppRoleRepository(DapperContext dapperContext) => _dapperContext = dapperContext;
      
        public async Task<ResponseViewModel> getByIdAppRole(Guid id)
        {
            var procedureName = Constant.spGetByIdAppRole;
            var parameters = new DynamicParameters();
            parameters.Add("@appRoleId", id, DbType.Guid);

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<AppRole>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getbyIdAppRole = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Get App User Data Found",
                    data = result
                };
                return getbyIdAppRole;
            }
        }

        public async Task<ResponseViewModel> getAllAppRole()
        {
            var procedureName = Constant.spGetAllAppRole;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<AppRole>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllAppRole = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Get All App User Data Found",
                    data = result
                };
                return getAllAppRole;
            }
        }

        public async Task<ResponseViewModel> addAppRole(AddAppRoleViewModel addAppRole)
        {
            var procedureName = Constant.spAddAppRole;

            addAppRole.createdBy = Guid.NewGuid();
            var parameters = new DynamicParameters();
            parameters.Add("@roleName", addAppRole.roleName, DbType.String);
            parameters.Add("@createdBy", addAppRole.createdBy, DbType.Guid);

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

        public async Task<ResponseViewModel> updateAppRole(UpdateAppRoleViewModel updateAppRoleViewModel)
        {
            var procedureName = Constant.spUpdateAppRole;

            var parameters = new DynamicParameters();
            parameters.Add("@appRoleId", updateAppRoleViewModel.appRoleId, DbType.Guid);
            parameters.Add("@roleName", updateAppRoleViewModel.roleName, DbType.String);
            parameters.Add("@updatedBy", updateAppRoleViewModel.updatedBy, DbType.Guid);

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

        public async Task<ResponseViewModel> deleteAppRole(DeleteAppRoleViewModel deleteAppRoleViewModel)
        {
            var procedureName = Constant.spDeleteAppRole;

            var parameters = new DynamicParameters();
            parameters.Add("@appRoleId", deleteAppRoleViewModel.appRoleId, DbType.Guid);
            parameters.Add("@updatedBy", deleteAppRoleViewModel.updatedBy, DbType.Guid);
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

        //new ticket 
        public async Task<ResponseViewModel> getAllTicket()
        {
            var response = new ResponseViewModel();
            var procedureName = Constant.spGetAllTicket;

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<Ticket>(procedureName, null, commandType: CommandType.StoredProcedure);

                    response.statusCode = result.Any() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound;
                    response.message = result.Any() ? "Get All Ticket User Data Found" : "Data Not Found";
                    response.data = result;
                }
            }
            catch (Exception ex)
            {
                response.statusCode = (int)HttpStatusCode.InternalServerError;
                response.message = $"An error occurred while fetching ticket data: {ex.Message}";
                response.data = null;
            }

            return response;
        }
      

        public async Task<ResponseViewModel> addTicket(AddTicketViewModel model)
        {
            string imagePath = null;
            var procedureName = Constant.spAddTicket;

            if (model.image != null && model.image.Length > 0)
            {
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.image.FileName);
                string uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/TicketImage");

                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }

                string filePath = Path.Combine(uploadDir, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.image.CopyToAsync(fileStream);
                }

                // Save only relative path
                imagePath = Path.Combine(uniqueFileName).Replace("\\", "/");
            }

            var parameters = new DynamicParameters();
            parameters.Add("@ticketType", model.ticketType, DbType.String);
            parameters.Add("@subject", model.subject, DbType.String);
            parameters.Add("@message", model.message, DbType.String);
            parameters.Add("@appUserId", model.appUserId, DbType.String);
            parameters.Add("@image", imagePath, DbType.String); // Save the image path
            parameters.Add("@createdBy", model.createdBy, DbType.Guid);

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(
                    procedureName, parameters, commandType: CommandType.StoredProcedure);

                if (result.statusCode == 1)
                {
                    result.statusCode = (int)HttpStatusCode.OK;
                }
                else
                {
                    result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                }

                return result;
            }
        }

        public async Task<ResponseViewModel> updateTicket(UpdateTicketViewModel model)
        {
            var response = new ResponseViewModel();
            var procedureName = Constant.spUpdateTicket;

            try
            {
                string imagePath = null;

                if (model.image != null && model.image.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.image.FileName);
                    string uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/TicketImage");

                    if (!Directory.Exists(uploadDir))
                    {
                        Directory.CreateDirectory(uploadDir);
                    }

                    string filePath = Path.Combine(uploadDir, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.image.CopyToAsync(fileStream);
                    }

                    imagePath = Path.Combine(uniqueFileName).Replace("\\", "/");
                }

                var parameters = new DynamicParameters();
                parameters.Add("@ticketId", model.ticketId, DbType.Guid);
                parameters.Add("@ticketType", model.ticketType, DbType.String);
                parameters.Add("@subject", model.subject, DbType.String);
                parameters.Add("@message", model.message, DbType.String);
                parameters.Add("@image", imagePath, DbType.String); // Updated
                parameters.Add("@active", model.active ? 1 : 0, DbType.Boolean);
                parameters.Add("@updatedBy", model.updatedBy, DbType.Guid);

                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(
                        procedureName, parameters, commandType: CommandType.StoredProcedure);

                    response.statusCode = result.statusCode == 1
                        ? (int)HttpStatusCode.OK
                        : (int)HttpStatusCode.ExpectationFailed;

                    response.message = result.message;
                    response.data = result.data;
                }
            }
            catch (Exception ex)
            {
                response.statusCode = (int)HttpStatusCode.InternalServerError;
                response.message = $"An error occurred: {ex.Message}";
            }

            return response;
        }

   
        public async Task<ResponseViewModel> deleteTicket(DeleteTicketViewModel deleteTicketViewModel)
        {
            var procedureName = Constant.spDeleteTicket;

            var parameters = new DynamicParameters();
            parameters.Add("@ticketId", deleteTicketViewModel.ticketId, DbType.Guid);
            parameters.Add("@updatedBy", deleteTicketViewModel.updatedBy, DbType.Guid);
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


        //-reply ticket

        public async Task<ResponseViewModel> getAllTicketReply()
        {
            var procedureName = Constant.spGetAllTicketReply;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<TicketReply>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllAppRole = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Get All Ticket Data Found",
                    data = result
                };
                return getAllAppRole;
            }
        }

        public async Task<ResponseViewModel> addTicketReply(AddTicketReplyViewModel model)
        {
            string imagePath = null;
            var procedureName = Constant.spAddTicketReply;

            if (model.image != null && model.image.Length > 0)
            {
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.image.FileName);
                string uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/TicketImage");

                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }

                string filePath = Path.Combine(uploadDir, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.image.CopyToAsync(fileStream);
                }

                imagePath = Path.Combine(uniqueFileName).Replace("\\", "/");
            }

            var parameters = new DynamicParameters();
            parameters.Add("@ticketId", model.ticketId, DbType.Guid);
            parameters.Add("@ticketType", model.ticketType, DbType.String);
            parameters.Add("@message", model.message, DbType.String);
            parameters.Add("@appUserId", model.appUserId, DbType.String);
            parameters.Add("@image", imagePath, DbType.String); 
            parameters.Add("@createdBy", model.createdBy, DbType.Guid);

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(
                    procedureName, parameters, commandType: CommandType.StoredProcedure);

                if (result.statusCode == 1)
                {
                    result.statusCode = (int)HttpStatusCode.OK;
                }
                else
                {
                    result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                }

                return result;
            }
        }


        public async Task<ResponseViewModel> updateTicketReply(UpdateTicketReplyViewModel model)
        {
            var response = new ResponseViewModel();
            var procedureName = Constant.spUpdateTicketReply;

            try
            {
                string imagePath = null;

                if (model.image != null && model.image.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.image.FileName);
                    string uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/TicketImage");

                    if (!Directory.Exists(uploadDir))
                    {
                        Directory.CreateDirectory(uploadDir);
                    }

                    string filePath = Path.Combine(uploadDir, uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.image.CopyToAsync(stream);
                    }

                    imagePath = Path.Combine(uniqueFileName).Replace("\\", "/");
                }

                var parameters = new DynamicParameters();
                parameters.Add("@ticketReplyId", model.ticketReplyId, DbType.Guid);
                parameters.Add("@ticketId", model.ticketId, DbType.Guid);
                parameters.Add("@ticketType", model.ticketType, DbType.String);
                parameters.Add("@message", model.message, DbType.String);
                parameters.Add("@appUserId", model.message, DbType.String);
                parameters.Add("@image", imagePath, DbType.String); 
                parameters.Add("@active", model.active ? 1 : 0, DbType.Boolean);
                parameters.Add("@updatedBy", model.updatedBy, DbType.Guid);

                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(
                        procedureName, parameters, commandType: CommandType.StoredProcedure);

                    response.statusCode = result.statusCode == 1
                        ? (int)HttpStatusCode.OK
                        : (int)HttpStatusCode.ExpectationFailed;

                    response.message = result.message;
                }
            }
            catch (Exception ex)
            {
                response.statusCode = (int)HttpStatusCode.InternalServerError;
                response.message = $"Error: {ex.Message}";
            }

            return response;
        }

        public async Task<ResponseViewModel> deleteTicketReply(DeleteTicketReplyViewModel deleteTicketReplyViewModel)
        {
            var procedureName = Constant.spDeleteTicketReply;

            var parameters = new DynamicParameters();
            parameters.Add("@ticketReplyId", deleteTicketReplyViewModel.ticketReplyId, DbType.Guid);
            parameters.Add("@updatedBy", deleteTicketReplyViewModel.updatedBy, DbType.Guid);
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
