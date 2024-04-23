using Payments.Domain.Entities;

namespace Payments.Application.Interactors.Abstractions
{
    public interface IGetApprovedAuthorizationsInteractor
    {
        Task<List<ApprovedAuthorization>> Execute();
    }
}
