using PaymentTrackerApi.DTOs;
using PaymentTrackerApi.Entities;

namespace PaymentTrackerApi.Services.Interfaces
{
    public interface IUserService
    {
        /// Yeni kullanıcı kaydeder, kayıt başarılıysa DTO döner
        Task<UserResponseDto?> RegisterAsync(UserRegisterDto registerDto);

        /// Email ve şifreye göre giriş yapar, başarıloysa kullanıcı DTO döner
        Task<UserResponseDto?> LoginAsync(UserLoginDto loginDto);
    }
}
