namespace PaymentTrackerApi.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string PaymentType { get; set; } = null!; // Örn: Kredi kartı, Nakit
        
        // Foreign Key
        public int UserId { get; set; }

        // Navigation property
        public User? User { get; set; } 
    }
}
