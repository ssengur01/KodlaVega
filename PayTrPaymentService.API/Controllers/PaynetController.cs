using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Business;
using PaymentService.Domain.Models;

namespace PaymentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaynetController : ControllerBase
    {
        private readonly PaynetManager _paymentManager;

        public PaynetController(PaynetManager paymentManager)
        {
            _paymentManager = paymentManager;
        }

        
        [HttpPost("payment")]
        public async Task<IActionResult> Payment([FromBody] PaynetRequest request)
        {
            var res = await _paymentManager.ProcessCardAsync(request);
            if (res.IsSucceed) return Ok(res);
            return BadRequest(res);
        }

       
        [HttpPost("charge")]
        public async Task<IActionResult> Charge([FromBody] PaynetChargeRequest request)
        {
            var res = await _paymentManager.ChargeWithTokenAsync(request);
            if (res.IsSucceed) return Ok(res);
            return BadRequest(res);
        }

        [HttpPost("tds-initial")]
        public async Task<IActionResult> Start3DSecure([FromBody] Paynet3DInitialRequest request)
        {
            var res = await _paymentManager.Start3DSecureAsync(request);
            if (!res.IsSucceed)
                return BadRequest(new { status = "failed", message = res.Message });

        
            return Ok(new
            {
                html_content = res.HtmlContent
            });
        }

     
        [HttpPost("tds-charge")]
        public async Task<IActionResult> Complete3DSecure([FromBody] Paynet3DChargeRequest request)
        {
            var res = await _paymentManager.Complete3DSecureAsync(request);
            if (!res.IsSucceed)
                return BadRequest(new { status = "failed", message = res.Message });

            return Ok(new
            {
                status = "success",
                message = "Ödeme başarılı!"
            });
        }
    }
}