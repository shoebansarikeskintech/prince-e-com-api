using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class AddIngredientViewModel
    {
        [Required]
        public string? name { get; set; }
        [Required]
        public string? description { get; set; }
        [Required]
        public Guid createdBy { get; set; }
    }
    public class DeleteIngredientViewModel
    {
        [Required]
        public Guid ingredientId { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
    public class UpdateIngredientViewModel
    {
        [Required]
        public Guid ingredientId { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public string? description { get; set; }
        [Required]
        public bool active { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
}
