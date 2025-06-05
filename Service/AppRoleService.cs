using RepositoryContract;
using ServiceContract;
using ViewModel;

namespace Service
{
    public class AppRoleService : IAppRoleContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public AppRoleService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseViewModel> getByIdAppRole(Guid appRoleId)
        {
            var getByIdAppRole = await _repositoryManager.appRoleRepository.getByIdAppRole(appRoleId);
            return getByIdAppRole;
        }

        public async Task<ResponseViewModel> getAllAppRole()
        {
            var getAllAppRole = await _repositoryManager.appRoleRepository.getAllAppRole();
            return getAllAppRole;
        }

        public async Task<ResponseViewModel> addAppRole(AddAppRoleViewModel addAppRoleViewModel)
        {
            var addAppRole = await _repositoryManager.appRoleRepository.addAppRole(addAppRoleViewModel);
            return addAppRole;
        }

        public async Task<ResponseViewModel> updateAppRole(UpdateAppRoleViewModel updateAppRoleViewModel)
        {
            var updateAppRole = await _repositoryManager.appRoleRepository.updateAppRole(updateAppRoleViewModel);
            return updateAppRole;
        }

        public async Task<ResponseViewModel> deleteAppRole(DeleteAppRoleViewModel deleteAppRoleViewModel)
        {
            var deleteAppRole = await _repositoryManager.appRoleRepository.deleteAppRole(deleteAppRoleViewModel);
            return deleteAppRole;
        }

        //new ticket
        public async Task<ResponseViewModel> getAllTicket()
        {
            var getAllTicket = await _repositoryManager.appRoleRepository.getAllTicket();
            return getAllTicket;
        }

        public async Task<ResponseViewModel> addTicket(AddTicketViewModel addTicketViewModel)
        {
            var addTicket = await _repositoryManager.appRoleRepository.addTicket(addTicketViewModel);
            return addTicket;
        }

        public async Task<ResponseViewModel> updateTicket(UpdateTicketViewModel updateTicketViewModel)
        {
            var updateTicket = await _repositoryManager.appRoleRepository.updateTicket(updateTicketViewModel);
            return updateTicket;
        }

        public async Task<ResponseViewModel> deleteTicket(DeleteTicketViewModel deleteTicketViewModel)
        {
            var deleteTicket = await _repositoryManager.appRoleRepository.deleteTicket(deleteTicketViewModel);
            return deleteTicket;
        }


        //ticket reply

        public async Task<ResponseViewModel> getAllTicketReply()
        {
            var getAllTicketReply = await _repositoryManager.appRoleRepository.getAllTicketReply();
            return getAllTicketReply;
        }

        public async Task<ResponseViewModel> addTicketReply(AddTicketReplyViewModel addTicketReplyViewModel)
        {
            var addTicketReply = await _repositoryManager.appRoleRepository.addTicketReply(addTicketReplyViewModel);
            return addTicketReply;
        }

        public async Task<ResponseViewModel> updateTicketReply(UpdateTicketReplyViewModel updateTicketReplyViewModel)
        {
            var updateTicketReply = await _repositoryManager.appRoleRepository.updateTicketReply(updateTicketReplyViewModel);
            return updateTicketReply;
        }

        public async Task<ResponseViewModel> deleteTicketReply(DeleteTicketReplyViewModel deleteTicketReplyViewModel)
        {
            var deleteTicketReply = await _repositoryManager.appRoleRepository.deleteTicketReply(deleteTicketReplyViewModel);
            return deleteTicketReply;
        }
    }
}
