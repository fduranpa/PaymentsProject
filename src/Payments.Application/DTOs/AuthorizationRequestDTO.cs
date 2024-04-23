using Struct = Payments.Domain.Structs;

namespace Payments.Application.DTOs
{
    public class AuthorizationRequestDTO
    {
        private int _authorizationType;

        public string ClientId { get; set; }
        public decimal Amount { get; set; }
        public int ClientType { get; set; }
        public int AuthorizationType
        {
            get => _authorizationType;
            set => _authorizationType = Struct.AuthorizationType.FromAuthorizationType(value);
        }
    }
}
