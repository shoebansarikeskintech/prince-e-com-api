using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
   public class UpdateRefundOrderStatusViewModel
    {
        public Guid adminUserId { get; set; }
        public Guid returnId { get; set; }
        public string? returnStatus { get; set; }
        public string? refundStatus { get; set; }
        public Guid updatedBy { get; set; }
    }
}
