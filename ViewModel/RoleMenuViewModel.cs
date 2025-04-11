using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class AddRoleMenuViewModel
    {
        [Required]
        public Guid appRoleId { get; set; }
        [Required]
        public Guid menuId { get; set; }
        [Required]
        public Guid subMenuId { get; set; }
        [Required]
        public Guid createdBy { get; set; }
    }
    public class DeleteRoleMenuViewModel
    {
        [Required]
        public Guid roleMenuId { get; set; }
        [Required]
        public Guid appRoleId { get; set; }
        [Required]
        public Guid menuId { get; set; }
        [Required]
        public Guid subMenuId { get; set; }  
        [Required]
        public Guid updatedBy { get; set; }
    }
    public class UpdateRoleMenuViewModel
    {
        [Required]
        public Guid roleMenuId { get; set; }
        [Required]
        public Guid appRoleId { get; set; }
        [Required]
        public Guid menuId { get; set; }
        [Required]
        public Guid subMenuId { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
}
