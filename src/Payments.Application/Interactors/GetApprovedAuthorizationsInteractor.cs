using Payments.Application.Gateways;
using Payments.Application.Interactors.Abstractions;
using Payments.Domain.Entities;

namespace Payments.Application.Interactors
{
    public class GetApprovedAuthorizationsInteractor : IGetApprovedAuthorizationsInteractor
    {
        private readonly IAuthorizationGateway _authorizationGateway;

        public GetApprovedAuthorizationsInteractor(IAuthorizationGateway authorizationGateway)
        {
            _authorizationGateway = authorizationGateway;
        }
        public async Task<List<ApprovedAuthorization>> Execute()
        {
            var approvedAuthorizations = await _authorizationGateway.GetRegistersApprovedAuthorizations();
            return approvedAuthorizations;
        }
    }
}
