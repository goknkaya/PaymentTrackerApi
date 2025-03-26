﻿namespace PaymentTrackerApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        //Navigation property
        public List<Payment> Payments { get; set; } = new();
    }
}
