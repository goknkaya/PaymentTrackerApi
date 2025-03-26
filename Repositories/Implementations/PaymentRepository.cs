using Microsoft.EntityFrameworkCore;
using PaymentTrackerApi.Data;
using PaymentTrackerApi.Entities;
using PaymentTrackerApi.Repositories.Interfaces;

namespace PaymentTrackerApi.Repositories.Implementations
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;
        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        // Veritabanında userId eşleşen tüm ödeme kayıtlarını getirir
        public async Task<List<Payment>> GetByUserIdAsync(int userId)
        {
            return await _context.Payments
                .Where(p=>p.UserId == userId)
                .ToListAsync();
        }

        // ID' si verilen tek bir ödeme kaydını getirir
        public async Task<Payment?> GetByIdAsync(int id)
        {
            return await _context.Payments.FirstOrDefaultAsync(p => p.Id == id);
        }

        // Yeni ödeme kaydını veritabanına ekler (henüz kalıcı değildir)
        public async Task AddAsync(Payment payment)
        {
            await _context.Payments .AddAsync(payment);
        }

        // Veritabanındaki değişiklikleri kalıcı olarak kaydeder
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }    }
}
