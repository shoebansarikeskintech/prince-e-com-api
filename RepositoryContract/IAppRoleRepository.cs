using ViewModel;

namespace RepositoryContract
{
    public interface IAppRoleRepository
    {
        public Task<ResponseViewModel> getByIdAppRole(Guid id);
        public Task<ResponseViewModel> getAllAppRole();
        public Task<ResponseViewModel> addAppRole(AddAppRoleViewModel addAppRoleViewModel);
        public Task<ResponseViewModel> updateAppRole(UpdateAppRoleViewModel updateAppRoleViewModel);
        public Task<ResponseViewModel> deleteAppRole(DeleteAppRoleViewModel deleteAppRoleViewModel);

        //New ticket 
        public Task<ResponseViewModel> getAllTicket();
        public Task<ResponseViewModel> addTicket(AddTicketViewModel addTicketViewModel);
        public Task<ResponseViewModel> updateTicket(UpdateTicketViewModel updateTicketViewModel);
        public Task<ResponseViewModel> deleteTicket(DeleteTicketViewModel deleteTicketViewModel);

        //ticket Reply
        public Task<ResponseViewModel> getAllTicketReply();
        public Task<ResponseViewModel> addTicketReply(AddTicketReplyViewModel addTicketReplyViewModel);
        public Task<ResponseViewModel> updateTicketReply(UpdateTicketReplyViewModel updateTicketReplyViewModel);
        public Task<ResponseViewModel> deleteTicketReply(DeleteTicketReplyViewModel deleteTicketReplyViewModel);
    }
}
