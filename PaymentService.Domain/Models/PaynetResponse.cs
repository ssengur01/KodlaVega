using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Domain.Models
{
    public class PaynetResponse
    {
        public long? Id { get; set; }
        public string? XactId { get; set; }
        public DateTime? XactDate { get; set; }
        public bool IsSucceed { get; set; }
        public string? Message { get; set; }
        public string? CardHolder { get; set; }
        public double? Amount { get; set; }
        public double? NetAmount { get; set; }
        public double? Comission { get; set; }
        public string? Currency { get; set; }
        public string? BankName { get; set; }
        public string? ReferenceNo { get; set; }
        public string? RawResponse { get; set; }
        public string? HtmlContent { get; set; }
    }
}
