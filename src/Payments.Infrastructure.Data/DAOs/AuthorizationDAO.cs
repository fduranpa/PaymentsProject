using Microsoft.EntityFrameworkCore;
using Payments.Application.DTOs;
using Payments.Application.Gateways;
using Payments.Domain.Entities;
using Payments.Infrastructure.Data.Context;
using Payments.Infrastructure.Data.Mappers;

namespace Payments.Infrastructure.Data.DAOs
{
    public class AuthorizationDAO : IAuthorizationGateway
    {
        private readonly AuthorizationContext _authorizationContext;

        public AuthorizationDAO(AuthorizationContext authorizationContext)
        {
            _authorizationContext = authorizationContext;
        }

        public async Task RegisterAuthorization(AuthorizationRequestDTO authorization, bool status)
        {
            await _authorizationContext.Authorizations.AddRangeAsync(authorization.AsAuthorizationModel(status));
            _authorizationContext.SaveChanges();
        }

        public async Task RegisterApprovedAuthorization(AuthorizationRequestDTO authorization)
        {
            await _authorizationContext.ApprovedAuthorizations.AddRangeAsync(authorization.AsApprovedAuthorizationModel());
            _authorizationContext.SaveChanges();
        }

        public async Task<List<ApprovedAuthorization>> GetRegistersApprovedAuthorizations()
        {
            var approbedAuthorizationsModel = await _authorizationContext.ApprovedAuthorizations.ToListAsync();
            return approbedAuthorizationsModel.Select(a => a.AsApprovedAuthorization()).ToList();
        }
    }
}
