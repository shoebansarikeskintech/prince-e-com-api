

using ViewModel;

namespace ServiceContract
{
   public interface INotificationContract
    {
        public Task<ResponseViewModel> getByIdNotification(Guid notificationId);
        public Task<ResponseViewModel> getAllNotification();
        public Task<ResponseViewModel> getAllNotificationForUser();
        public Task<ResponseViewModel> addNotification(AddNotificationViewModel addNotification);
        public Task<ResponseViewModel> updateNotification(UpdateNotificationViewModel updateNotification);
        public Task<ResponseViewModel> deleteNotification(DeleteNotificationViewModel deleteNotification);
    }
}
