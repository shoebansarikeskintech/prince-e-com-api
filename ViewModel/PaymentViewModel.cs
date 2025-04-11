using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class AddPaymentModeViewModel
    {
        [Required]
        public string? paymentName { get; set; }
        [Required]
        public Guid createdBy { get; set; }
    }
    public class UpdatePaymentModeViewModel
    {
        [Required]
        public Guid paymentModeId { get; set; }
        [Required]
        public string? paymentName { get; set; }

        [Required]
        public Guid updatedBy { get; set; }
        [Required]
        public bool active { get; set; }
    }
    public class DeletePaymentModeViewModel
    {
        [Required]
        public Guid paymentModeId { get; set; }
        [Required]
        public Guid updatedBy { get; set; }

    }
}