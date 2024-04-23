using Payments.Application.DTOs;
using Payments.Domain.Entities;
using Payments.Infrastructure.Data.Models;

namespace Payments.Infrastructure.Data.Mappers
{
    public static class EntityMappersExtensions
    {
        public static AuthorizationModel AsAuthorizationModel(this AuthorizationRequestDTO authorizationRequest, bool approved)
        {
            return new AuthorizationModel
            {
                ClientId = authorizationRequest.ClientId,
                Amount = Math.Round(authorizationRequest.Amount, 3),
                ClientType = authorizationRequest.ClientType,
                AuthorizationType = authorizationRequest.AuthorizationType,
                State = approved
            };
        }

        public static ApprovedAuthorizationModel AsApprovedAuthorizationModel(this AuthorizationRequestDTO authorizationRequest)
        {
            return new ApprovedAuthorizationModel
            {
                ClientId = authorizationRequest.ClientId,
                Amount = Math.Round(authorizationRequest.Amount, 3),
                Date = DateTime.Now
            };
        }

        public static ApprovedAuthorization AsApprovedAuthorization(this ApprovedAuthorizationModel authorizationRequest)
        {
            return new ApprovedAuthorization
            {
                Id = authorizationRequest.Id,
                ClientId = authorizationRequest.ClientId,
                Amount = Math.Round(authorizationRequest.Amount, 3),
                Date = DateTime.Now
            };
        }
    }
}
