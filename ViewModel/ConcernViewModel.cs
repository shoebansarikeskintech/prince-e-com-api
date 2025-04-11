using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ConcernViewModel
    {
        public class AddConcernViewModel
        {
            [Required]
            public string? name { get; set; }
            public string? description { get; set; }
            [Required]
            public Guid createdBy { get; set; }
        }
        public class DeleteConcernViewModel
        {
            [Required]
            public Guid ConcernId { get; set; }
            [Required]
            public Guid updatedBy { get; set; }
        }
        public class UpdateConcernViewModel
        {
            [Required]
            public Guid ConcernId { get; set; }
            [Required]
            public string? name { get; set; }           
            public string? description { get; set; }
            [Required]
            public bool active { get; set; }
            [Required]
            public Guid updatedBy { get; set; }
        }
    }
}
