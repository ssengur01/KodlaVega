using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PaymentService.Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace PaymentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaynetNotificationController : ControllerBase
    {
        private readonly PaynetSettings _settings;

        public PaynetNotificationController(IOptions<PaynetSettings> opts)
        {
            _settings = opts.Value;
        }


        [HttpPost("notification")]
        public async Task<IActionResult> Notification()
        {
            using var sr = new StreamReader(Request.Body);
            var body = await sr.ReadToEndAsync();

            
            if (!string.IsNullOrWhiteSpace(_settings.WebhookSecret))
            {
                if (!Request.Headers.TryGetValue("X-Signature", out var sig)) return BadRequest("missing signature");
                var expected = ComputeHmacSha256(_settings.WebhookSecret, body);
                if (!string.Equals(expected, sig.ToString()))
                    return BadRequest("invalid signature");
            }

           
            var json = System.Text.Json.JsonDocument.Parse(body).RootElement;
            var merchantOid = json.TryGetProperty("reference_no", out var r) ? r.GetString() : null;
            var status = json.TryGetProperty("is_succeed", out var s) ? s.GetBoolean() : false;

           
            return Content("OK");
        }

        private static string ComputeHmacSha256(string key, string data)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var dataBytes = Encoding.UTF8.GetBytes(data);
            using var hmac = new HMACSHA256(keyBytes);
            return Convert.ToBase64String(hmac.ComputeHash(dataBytes));
        }
    }
}
