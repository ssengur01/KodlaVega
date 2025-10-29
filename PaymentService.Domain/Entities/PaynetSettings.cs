using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Domain.Entities
{
    public class PaynetSettings
    {
        public string ApiBaseUrl { get; set; } = "https://api.paynet.com.tr";
        public string SecretKey { get; set; } = "";
        public string PublishableKey { get; set; } = "";
        public string ChargePath { get; set; } = "/v1/transaction/charge";
        public string PaymentPath { get; set; } = "/v2/transaction/payment";
        public string NotificationUrl { get; set; } = "";
        public string WebhookSecret { get; set; } = "";
        public string TdsInitialPath { get; set; } = "v2/transaction/tds_initial";
        public string TdsChargePath { get; set; } = "v2/transaction/tds_charge";
    }
}
