namespace Payments.Infrastructure.Data.Models
{
    public class ApprovedAuthorizationModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string ClientId { get; set; }
    }
}
