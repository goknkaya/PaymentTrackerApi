using Microsoft.EntityFrameworkCore;
using PaymentTrackerApi.Data;
using PaymentTrackerApi.Entities;
using PaymentTrackerApi.Repositories.Interfaces;

namespace PaymentTrackerApi.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        // Veritabanından ID' ye göre kullanıcı getirir
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        // E-mail' e göre kullanıcı getirir (kayıt kontrolünde kullanılır)
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        // Kullanıcıyı veritabanına ekler ama henüz kayıt yapmaz
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        // Veritabanına yapılan tüm değişiklikleri kalıcı hale getirir
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
