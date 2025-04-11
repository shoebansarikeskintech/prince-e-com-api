
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class AddNotificationViewModel
    {
        [Required]
        public string? title { get; set; }
        [Required]
        public string? descrption { get; set; }
        [Required]
        public string? status { get; set; }
        [Required]
        public Guid createdBy { get; set; }
    }
    public class DeleteNotificationViewModel
    {
        [Required]
        public Guid notificationId { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
    public class UpdateNotificationViewModel
    {
        [Required]
        public Guid notificationId { get; set; }
        [Required]
        public string? title { get; set; }
        [Required]
        public string? descrption { get; set; }
        [Required]
        public string? status { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
}
