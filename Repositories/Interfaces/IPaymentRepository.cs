using PaymentTrackerApi.Entities;

namespace PaymentTrackerApi.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        /// <summary>
        /// Belirli bir kullanıcıya ait tüm ödemeleri getirir
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<Payment>> GetByUserIdAsync(int userId);

        /// <summary>
        /// Ödeme ID' sine göre tek bir ödeme getirir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Payment?> GetByIdAsync(int id);

        /// <summary>
        /// Yeni bir ödeme kaydını veritabanına ekler (SaveChanges çağırılmalı)
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        Task AddAsync(Payment payment);

        /// <summary>
        /// Yapılan veritabanı değişikliklerini kaydeder
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveChangesAsync();
    }
}
