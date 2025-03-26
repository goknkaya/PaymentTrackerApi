namespace PaymentTrackerApi.DTOs
{
    public class PaymentResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string PaymentType { get; set; } = null!;
    }
}
