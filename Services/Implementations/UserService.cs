using System.Security.Cryptography;
using System.Text;
using PaymentTrackerApi.DTOs;
using PaymentTrackerApi.Entities;
using PaymentTrackerApi.Repositories.Interfaces;
using PaymentTrackerApi.Services.Interfaces;

namespace PaymentTrackerApi.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) // Constructor, veritabani islemleri icin kullaniliyor
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponseDto?> RegisterAsync(UserRegisterDto registerDto) // Yeni kullanici kaydi kontrolu
        {
            var existingUser = await _userRepository.GetByEmailAsync(registerDto.Email); // EMail kontrolu
            if (existingUser != null)
            {
                return null;
            }

            var hashedPassword = HashPassword(registerDto.Password); // Sifreyi guvenlik icin hash' liyoruz

            var user = new User // Yeni kullanici nesnesi olusturuyoruz DB' ye kaydedilecek veri
            {
                FullName = registerDto.FullName,
                Email = registerDto.Email,
                PasswordHash = hashedPassword
            };

            await _userRepository.AddAsync(user); // Repository yardimiyla User' i DB' ye ekliyoruz
            await _userRepository.SaveChangesAsync();

            return new UserResponseDto // Cevap donuyoruz frontEnd' de arayuze (password gibi ozel alani donmeyiz)
            {
                Id = user.Id,
                FullName = registerDto.FullName,
                Email = registerDto.Email
            };
        }

        public async Task<UserResponseDto?> LoginAsync(UserLoginDto loginDto) // Kayitli kullanici kontrolu
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email); // EMail kontrolu
            if (user != null)
            {
                return null;
            }

            var hashedPassword = HashPassword(loginDto.Password); // Sifreyi guvenlik icin hash' liyoruz
            if(user.PasswordHash != hashedPassword)
            {
                return null;
            }

            return new UserResponseDto // Cevap donuyoruz frontEnd' de arayuze (password gibi ozel alani donmeyiz)
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email
            };
        }

        private string HashPassword(string password) // Sifreleme fonksiyonu
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

    }
}
