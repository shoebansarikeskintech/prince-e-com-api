using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class RatingReviewViewModel
    {

        [Required]
        public Guid productId { get; set; }
        [Required]
        public Guid userId { get; set; }
        [Required]
        public Int64 rating { get; set; }
        [Required]
        public string? title { get; set; }
        [Required]
        public string? description { get; set; }
        public Int64 like { get; set; }
        public Int64 dislike { get; set; }
        [Required]
        public Guid createdBy { get; set; }         

    }
}
