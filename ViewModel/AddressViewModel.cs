using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
   public class AddAddressViewModel
    {
        [Required]
        public Guid userId { get; set; }
        public string? addressType { get; set; }
        [Required]
        public bool isDefualt { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public string? mobile { get; set; }
        [Required]
        public string? email { get; set; }
        [Required]
        public string? streetAddress { get; set; }
        [Required]
        public string? state { get; set; }
        [Required]
        public string? city { get; set; }
        [Required]
        public string? pincode { get; set; }
        [Required]
        public string? country { get; set; }
        [Required]
        public Guid createdBy { get; set; }
    }

    public class UpdateAddressViewModel
    {
        [Required]
        public Guid userId { get; set; }
        public string? addressType { get; set; }
        [Required]
        public Guid addressId { get; set; }
        [Required]
        public bool isDefualt { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public string? mobile { get; set; }
        [Required]
        public string? email { get; set; }
        [Required]
        public string? streetAddress { get; set; }
        [Required]
        public string? state { get; set; }
        [Required]
        public string? city { get; set; }
        [Required]
        public string? pincode { get; set; }
        [Required]
        public string? country { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }

    public class DeleteAddressViewModel
    {
        [Required]
        public Guid userId { get; set; }
        [Required]
        public Guid addressId { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
}
