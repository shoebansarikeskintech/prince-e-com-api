
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class AddGiftCardViewModel
    {
        [Required]
        public Guid appUserId { get; set; }
        [Required]
        public Guid cardNumber { get; set; }
        [Required]
        public string? balance { get; set; }
        [Required]
        public string? status { get; set; }
        [Required]
        public DateTime? issueDate { get; set; }
        [Required]
        public DateTime? expireDate { get; set; }
        [Required]
        public Guid createdBy { get; set; }
    }

    public class UpdateGiftCardViewModel
    {
        [Required]
        public Guid giftCardId { get; set; }
        [Required]
        public Guid appUserId { get; set; }
        [Required]
        public string? cardNumber { get; set; }
        [Required]
        public string? balance { get; set; }
        [Required]
        public string? status { get; set; }
        [Required]
        public DateTime? issueDate { get; set; }
        [Required]
        public DateTime? expireDate { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }

    public class DeleteGiftCardViewModel
    {
        [Required]
        public Guid giftCardId { get; set; }
        [Required]
        public Guid appUserId { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
}
