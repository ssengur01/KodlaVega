using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Domain.Models
{
    public class Paynet3DInitialRequest
    {
        public string CardNumber { get; set; } = string.Empty;
        public string ExpMonth { get; set; } = string.Empty;
        public string ExpYear { get; set; } = string.Empty;
        public string Cvc { get; set; } = string.Empty;
        public string CardHolder { get; set; } = string.Empty;
        public int Amount { get; set; }
        public string OrderId { get; set; } = string.Empty;
        public string ReturnUrl { get; set; } = string.Empty;
        public string ReferenceNo { get; set; } = string.Empty;
        public string Pan { get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;
    }
}
