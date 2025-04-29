
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class AddMenuViewModel
    {
        [Required]
        public string? menuName { get; set; }
        [Required]
        public int displayOrder { get; set; }
        [Required]
        public Guid createdBy { get; set; }

        [Required]
        public string? menuIcon { get; set; }
    }
    public class DeleteMenuViewModel
    {
        [Required]
        public Guid menuId { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
    public class UpdateMenuViewModel
    {
        [Required]
        public Guid menuId { get; set; }
        [Required]
        public string? menuName { get; set; }
        [Required]
        public string? pageName { get; set; }
        [Required]
        public string? controllerName { get; set; }
        [Required]
        public string? actionName { get; set; }
        [Required]
        public int displayOrder { get; set; }
        [Required]
        public Guid updatedBy { get; set; }

        [Required]
        public string? menuIcon { get; set; }
        public bool active { get; set; }
    }

    public class MenuByUserRoleViewModel
    {
        [Required]
        public string? userName { get; set; }
    }
}
