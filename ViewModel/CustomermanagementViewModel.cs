using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
   public class UpdateProfileViewModel
    {
        [Required]
        public Guid userId { get; set; }
        [Required]
        public string? firstName { get; set; }
        public string? middleName { get; set; }
        public string? lastName { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }

    public class UpdatePasswordViewModel
    {
        [Required]
        public Guid userId { get; set; }
        [Required]
        public string? password { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
}
