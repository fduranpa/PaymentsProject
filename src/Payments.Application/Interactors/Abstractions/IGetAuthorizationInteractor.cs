using Payments.Application.DTOs;

namespace Payments.Application.Interactors.Abstractions
{
    public interface IGetAuthorizationInteractor
    {
        Task<AuthorizationResponseDTO> Execute(AuthorizationRequestDTO authorizationRequest);
    }
}
