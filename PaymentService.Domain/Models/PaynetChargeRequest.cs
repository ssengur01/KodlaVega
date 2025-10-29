using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Domain.Models
{
    public class PaynetChargeRequest
    {
        public string SessionId { get; set; } = string.Empty;
        public string TokenId { get; set; } = string.Empty;
        public int TransactionType { get; set; } = 1;
    }
}
