using Payments.Application.DTOs;
using Payments.Application.Gateways;

namespace Payments.Infrastructure.Services.Services
{
    public class PaymentProcessorService : IPaymentProcessorService
    {
        public async Task<PaymentAuthorizationDTO> ValidatePaymentAuthorization(decimal amount)
        {
            //The send POST Request is Simulated
            var endpointResponse = PostAuthorized(amount);
            return endpointResponse;
        }

        private PaymentAuthorizationDTO PostAuthorized(decimal amount)
        {
            var authorized = amount % 1 != 0;
            if (authorized)
                return new PaymentAuthorizationDTO { Approved = false };
            else
                return new PaymentAuthorizationDTO { Approved = true };
        }
    }
}
