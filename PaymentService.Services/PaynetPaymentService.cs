using Microsoft.Extensions.Options;
using PaymentService.Application;
using PaymentService.Domain.Entities;
using PaymentService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PaymentService.Services
{
    public class PaynetPaymentService : IPaynetService
    {
        private readonly HttpClient _http;
        private readonly PaynetSettings _settings;

        public PaynetPaymentService(HttpClient http, IOptions<PaynetSettings> opts)
        {
            _http = http;
            _settings = opts.Value;
            if (!string.IsNullOrWhiteSpace(_settings.ApiBaseUrl))
            {
                _http.BaseAddress = new Uri(_settings.ApiBaseUrl);
            }
        }

        public async Task<PaynetResponse> ChargeWithTokenAsync(PaynetChargeRequest request)
        {
            var payload = new
            {
                session_id = request.SessionId,
                token_id = request.TokenId,
                transaction_type = request.TransactionType
            };

            return await PostJsonAsync(_settings.ChargePath, payload);
        }

        public async Task<PaynetResponse> Complete3DSecureAsync(Paynet3DChargeRequest request)
        {
            var payload = new
            {
                session_id = request.SessionId,
                token_id = request.TokenId
            };

            return await PostJsonAsync(_settings.TdsChargePath, payload);
        }

        public async Task<PaynetResponse> ProcessCardPaymentAsync(PaynetRequest request)
        {
            var payload = new
            {
                amount = request.Amount,
                reference_no = request.ReferenceNo,
                domain = request.Domain,
                card_holder = request.CardHolder,
                pan = request.Pan,
                month = request.Month,
                year = request.Year,
                cvc = request.Cvc
            };

            return await PostJsonAsync(_settings.PaymentPath, payload);
        }

        public async Task<PaynetResponse> Start3DSecureAsync(Paynet3DInitialRequest request)
        {
            var payload = new
            {
                pan = request.Pan,
                month = request.ExpMonth,
                year = request.ExpYear,
                cvc = request.Cvc,
                card_holder = request.CardHolder,
                amount = request.Amount,
                currency = "TRY",
                order_id = request.OrderId,
                return_url = request.ReturnUrl,
                reference_no = request.ReferenceNo,
                description = request.Description
            };

            return await PostJsonAsync(_settings.TdsInitialPath, payload);
        }

        private async Task<PaynetResponse> PostJsonAsync(string path, object payload)
        {
            var json = JsonSerializer.Serialize(payload);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");

            
            _http.DefaultRequestHeaders.Accept.Clear();
            _http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            
            if (!string.IsNullOrWhiteSpace(_settings.SecretKey))
            {
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _settings.SecretKey);
            }

            HttpResponseMessage resp;
            try
            {
                
                resp = await _http.PostAsync(path, content);
            }
            catch (Exception ex)
            {
                return new PaynetResponse
                {
                    IsSucceed = false,
                    Message = "HTTP hatası: " + ex.Message
                };
            }

            var respStr = await resp.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(respStr))
            {
                return new PaynetResponse
                {
                    IsSucceed = false,
                    Message = "Boş cevap. StatusCode: " + resp.StatusCode,
                    RawResponse = respStr
                };
            }

            try
            {
                using var doc = JsonDocument.Parse(respStr);
                var root = doc.RootElement;

                var get = new Func<string, string?, string?>((name, alt) =>
                {
                    return root.TryGetProperty(name, out var el) ? el.ToString() : alt;
                });

                var response = new PaynetResponse
                {
                    RawResponse = respStr,
                    IsSucceed = root.TryGetProperty("is_succeed", out var s) && s.ValueKind != JsonValueKind.Null ? s.GetBoolean() : resp.IsSuccessStatusCode,
                    Message = root.TryGetProperty("message", out var m) ? m.GetString() : resp.ReasonPhrase,
                    ReferenceNo = root.TryGetProperty("reference_no", out var r) ? r.GetString() : null,
                    Currency = root.TryGetProperty("currency", out var c) ? c.GetString() : null,
                    BankName = root.TryGetProperty("bank_name", out var bn) ? bn.GetString() : null
                };

                if (root.TryGetProperty("id", out var idEl) && idEl.TryGetInt64(out var idVal)) response.Id = idVal;
                if (root.TryGetProperty("xact_id", out var xEl)) response.XactId = xEl.GetString();
                if (root.TryGetProperty("xact_date", out var xd) && xd.ValueKind == JsonValueKind.String && DateTime.TryParse(xd.GetString(), out var dtt)) response.XactDate = dtt;
                if (root.TryGetProperty("card_holder", out var ch)) response.CardHolder = ch.GetString();
                if (root.TryGetProperty("amount", out var am) && am.ValueKind == JsonValueKind.Number && am.TryGetDouble(out var amv)) response.Amount = amv;
                if (root.TryGetProperty("net_amount", out var na) && na.ValueKind == JsonValueKind.Number && na.TryGetDouble(out var nav)) response.NetAmount = nav;
                if (root.TryGetProperty("comission", out var cm) && cm.ValueKind == JsonValueKind.Number && cm.TryGetDouble(out var cmv)) response.Comission = cmv;

                return response;
            }
            catch (JsonException)
            {
                return new PaynetResponse
                {
                    IsSucceed = resp.IsSuccessStatusCode,
                    Message = "Geçersiz JSON: " + respStr,
                    RawResponse = respStr
                };
            }
        }
    }
}

