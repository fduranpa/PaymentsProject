namespace Payments.Domain.Entities
{
    public class ApprovedAuthorization
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string ClientId { get; set; }
    }
}
