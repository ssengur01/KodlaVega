using PaymentService.Application;
using PaymentService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Business
{
    public class PaynetManager
    {
       private readonly IPaynetService _paynetService;

        public PaynetManager(IPaynetService paynetService)
        {
            _paynetService = paynetService;
        }


        public Task<PaynetResponse> ProcessCardAsync(PaynetRequest request)
          => _paynetService.ProcessCardPaymentAsync(request);

        public Task<PaynetResponse> ChargeWithTokenAsync(PaynetChargeRequest request)
            => _paynetService.ChargeWithTokenAsync(request);

        public Task<PaynetResponse> Start3DSecureAsync(Paynet3DInitialRequest request)
           => _paynetService.Start3DSecureAsync(request);

       
        public Task<PaynetResponse> Complete3DSecureAsync(Paynet3DChargeRequest request)
            => _paynetService.Complete3DSecureAsync(request);
    }
}
