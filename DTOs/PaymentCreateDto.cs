namespace PaymentTrackerApi.DTOs
{
    public class PaymentCreateDTO
    {
        public string Title { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string PaymentType { get; set; } = null!;
    }
}
