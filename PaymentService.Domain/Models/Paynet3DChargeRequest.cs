using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Domain.Models
{
    public class Paynet3DChargeRequest
    {
        public string? SessionId { get; set; }
        public string? TokenId { get; set; }
    }
}
