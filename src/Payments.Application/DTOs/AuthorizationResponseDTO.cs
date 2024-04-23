using Payments.Domain.Messages;

namespace Payments.Application.DTOs
{
    public class AuthorizationResponseDTO
    {
        public bool Ok { get; set; }
        public IList<ValidationMessages> Messages { get; set; } = Enumerable.Empty<ValidationMessages>().ToList();
        public bool? Approved { get; set; }

        public AuthorizationResponseDTO(ValidationMessages messages)
        {
            Ok = false;
            Messages = new List<ValidationMessages> { messages };
        }

        public AuthorizationResponseDTO(PaymentAuthorizationDTO paymentAuthorization)
        {
            Ok = true;
            Approved = paymentAuthorization.Approved;
        }
    }
}
