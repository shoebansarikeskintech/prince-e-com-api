using RepositoryContract;
using ServiceContract;
using ViewModel;

namespace Service
{
   public class NotificationService : INotificationContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public NotificationService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseViewModel> getByIdNotification(Guid notificationId)
        {
            var getByIdSubCategory = await _repositoryManager.notificationRepository.getByIdNotification(notificationId);
            return getByIdSubCategory;
        }

        public async Task<ResponseViewModel> getAllNotification()
        {
            var getAllSubCategory = await _repositoryManager.notificationRepository.getAllNotification();
            return getAllSubCategory;
        }
        public async Task<ResponseViewModel> getAllNotificationForUser()
        {
            var getAllSubCategory = await _repositoryManager.notificationRepository.getAllNotificationForUser();
            return getAllSubCategory;
        }

        public async Task<ResponseViewModel> addNotification(AddNotificationViewModel addNotification)
        {
            var add = await _repositoryManager.notificationRepository.addNotification(addNotification);
            return add;
        }

        public async Task<ResponseViewModel> updateNotification(UpdateNotificationViewModel updateNotification)
        {
            var update = await _repositoryManager.notificationRepository.updateNotification(updateNotification);
            return update;
        }

        public async Task<ResponseViewModel> deleteNotification(DeleteNotificationViewModel deleteNotification)
        {
            var delete = await _repositoryManager.notificationRepository.deleteNotification(deleteNotification);
            return delete;
        }
    }
}
