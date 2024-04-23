using Payments.Application.DTOs;

namespace Payments.Application.Gateways
{
    public interface IPaymentProcessorService
    {
        Task<PaymentAuthorizationDTO> ValidatePaymentAuthorization(decimal amount);
    }
}
