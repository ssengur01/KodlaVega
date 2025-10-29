using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Domain.Models
{
    public class PaynetRequest
    {
        public string Amount { get; set; } = string.Empty; 
        public string ReferenceNo { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;
        public string CardHolder { get; set; } = string.Empty;
        public string Pan { get; set; } = string.Empty;
        public string Month { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string Cvc { get; set; } = string.Empty;
    }
}
