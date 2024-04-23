using Payments.Application.DTOs;
using Payments.Domain.Entities;

namespace Payments.Application.Gateways
{
    public interface IAuthorizationGateway
    {
        Task RegisterAuthorization(AuthorizationRequestDTO authorization, bool status);
        Task RegisterApprovedAuthorization(AuthorizationRequestDTO authorization);
        Task<List<ApprovedAuthorization>> GetRegistersApprovedAuthorizations();
    }
}
