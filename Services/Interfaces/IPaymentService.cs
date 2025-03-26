using PaymentTrackerApi.DTOs;

namespace PaymentTrackerApi.Services.Interfaces
{
    public interface IPaymentService
    {
        /// Kullanicinin tum odemelerini listeler <summary>
        /// Kullanıcı giriş yaptıktan sonra kendi ödemelerini görmek için kullanır

        Task<List<PaymentResponseDto>> GetPaymentsByUserIdAsync(int userId);

        /// Yeni odeme ekler
        /// paymentDto = gelen ödeme bilgileri
        /// userId = giriş yapan kullanıcıya ait ID
        Task<bool> AddPaymentAsync(PaymentCreateDTO paymentDto, int userId);
    }
}
