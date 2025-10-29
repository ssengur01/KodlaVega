using PaymentService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application
{
    public interface IPaynetService
    {
        Task<PaynetResponse> ProcessCardPaymentAsync(PaynetRequest request); 
        Task<PaynetResponse> ChargeWithTokenAsync(PaynetChargeRequest request);

        Task<PaynetResponse> Start3DSecureAsync(Paynet3DInitialRequest request);
        Task<PaynetResponse> Complete3DSecureAsync(Paynet3DChargeRequest request);
    }
}
