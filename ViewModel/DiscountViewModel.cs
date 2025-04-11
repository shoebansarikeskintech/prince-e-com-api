
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class AddDiscountViewModel
    {
        [Required]
        public Guid productId { get; set;}
        [Required]
        public string? code { get; set;}
        [Required]
        public string? discountType { get; set;}
        [Required]
        public string? discount { get; set;}
        [Required]
        public string? productAmount { get; set;}
        [Required]
        public DateTime? validDate { get; set;}
        [Required]
        public DateTime? expireDate { get; set;}
        [Required]
        public Guid createdBy { get; set;}
    }

    public class UpdateDiscountViewModel
    {
        [Required]
        public Guid discountId { get; set;}
        [Required]
        public Guid productId { get; set;}
        [Required]
        public string? code { get; set;}
        [Required]
        public string? discountType { get; set;}
        [Required]
        public string? discount { get; set;}
        [Required]
        public string? productAmount { get; set;}
        [Required]
        public DateTime? validDate { get; set;}
        [Required]
        public DateTime? expireDate { get; set;}
        [Required]
        public Guid updatedBy { get; set; }
    }

    public class DeleteDiscountViewModel
    {
        [Required]
        public Guid productId { get; set; }
        [Required]
        public Guid discountId { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
}
