using PaymentTrackerApi.Entities;

namespace PaymentTrackerApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Kullancıyı ID bilgisine göre getirir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User?> GetByIdAsync(int id);

        /// <summary>
        /// Kullanıcıyı e-mail bilgisine göre getirir
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User?> GetByEmailAsync(string email);

        /// <summary>
        /// Veritabanına yeni kullanıcı ekler (SaveChanges çağırılmalı)
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task AddAsync(User user);

        /// <summary>
        /// Yapılan veritabanı değişikliklerini kaydeder (true / false döner)
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveChangesAsync();
    }
}
