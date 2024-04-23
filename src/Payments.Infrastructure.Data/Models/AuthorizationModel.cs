namespace Payments.Infrastructure.Data.Models
{
    public class AuthorizationModel
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public decimal Amount { get; set; }
        public int ClientType { get; set; }
        public int AuthorizationType { get; set; }
        public bool State { get; set; }
    }
}
