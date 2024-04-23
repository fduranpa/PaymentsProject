using Payments.Application.DTOs;
using Payments.Application.Gateways;
using Payments.Application.Interactors.Abstractions;
using Payments.Domain.Structs;

namespace Payments.Application.Interactors
{
    public class GetAuthorizationInteractor : IGetAuthorizationInteractor
    {
        private readonly IPaymentProcessorService _paymentProcessorService;
        private readonly IAuthorizationGateway _authorizationGateway;
        public const int REVERSE = 3;

        public GetAuthorizationInteractor(IPaymentProcessorService paymentProcessorService, IAuthorizationGateway authorizationGateway)
        {
            _paymentProcessorService = paymentProcessorService;
            _authorizationGateway = authorizationGateway;
        }

        public async Task<AuthorizationResponseDTO> Execute(AuthorizationRequestDTO authorizationRequest)
        {
            if (ClientType.IsSecondClient(authorizationRequest.ClientType))
            {
                if (!await IsConfirmed(authorizationRequest))
                    authorizationRequest.AuthorizationType = REVERSE;
            }

            var response = await _paymentProcessorService.ValidatePaymentAuthorization(authorizationRequest.Amount);

            Task registerAuthorization = _authorizationGateway.RegisterAuthorization(authorizationRequest, response.Approved);
            Task registerApprovedAuthorization = Task.CompletedTask;
            if (response.Approved)
                registerApprovedAuthorization = _authorizationGateway.RegisterApprovedAuthorization(authorizationRequest);

            await Task.WhenAll(registerAuthorization, registerApprovedAuthorization);
            return new AuthorizationResponseDTO(response);
        }

        private async Task<bool> IsConfirmed(AuthorizationRequestDTO authorizationRequest)
        {
            await Task.Delay(TimeSpan.FromMinutes(5));
            return false;
        }
    }
}
