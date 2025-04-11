using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class AddAppRoleViewModel
    {
        [Required]
        public string? roleName { get; set; }
        [Required]
        public Guid createdBy { get; set; }
    }
    public class DeleteAppRoleViewModel
    {
        [Required]
        public Guid appRoleId { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }

    public class UpdateAppRoleViewModel
    {
        public Guid appRoleId { get; set; }
        [Required]
        public string? roleName { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
}
