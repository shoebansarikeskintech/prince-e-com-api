
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
        public string? discountType { get; set; }

        [Required]
        public decimal? discount { get; set; }

        [Required]
        public decimal? productAmount { get; set;}
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
        public decimal? discount { get; set;}
        [Required]
        public decimal? productAmount { get; set;}
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

    public class AddCouponViewModel
    {
        [Required]
        public string? code { get; set; }
        [Required]
        public string? details { get; set; }
        [Required]
        public string? amountType { get; set; }
        [Required]
        public decimal? amount { get; set; }      
        [Required]
        public Guid createdBy { get; set; }
    }

    public class UpdateCouponViewModel
    {
        [Required]
        public Guid couponId { get; set; }
        [Required]
        public string? code { get; set; }
        [Required]
        public string? details { get; set; }
        [Required]
        public string? amountType { get; set; }
        [Required]
        public decimal? amount { get; set; }
       
        [Required]
        public Guid updatedBy { get; set; }
        public bool active { get; set; }
    }

    public class DeleteCouponViewModel
    {
        [Required]
        public Guid couponId { get; set; }

        [Required]
        public Guid updatedBy { get; set; }
    }
}
