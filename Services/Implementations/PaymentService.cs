using PaymentTrackerApi.DTOs;
using PaymentTrackerApi.Entities;
using PaymentTrackerApi.Repositories.Interfaces;
using PaymentTrackerApi.Services.Interfaces;

namespace PaymentTrackerApi.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        // Repository'i constructor üzerinden alıyoruz (Dependency Injection)
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        // Verilen kullanıcı ID'sine ait tüm ödemeleri getirir
        // Gelen Payment entity listesini, DTO listesine dönüştürüp döner
        public async Task<List<PaymentResponseDto>> GetPaymentsByUserIdAsync(int userId)
        {
            var payments = await _paymentRepository.GetByUserIdAsync(userId);

            return payments.Select(p=>new PaymentResponseDto
            {
                Id = p.Id,
                Title = p.Title,
                Amount = p.Amount,
                Date = p.Date,
                PaymentType = p.PaymentType
            }).ToList();
        }

        // Yeni bir ödeme ekler
        // DTO'dan entity oluşturur ve veritabanına kaydeder
        public async Task<bool> AddPaymentAsync(PaymentCreateDTO paymentDto, int userId)
        {
            var payment = new Payment
            {
                Title = paymentDto.Title,
                Amount = paymentDto.Amount,
                Date = paymentDto.Date,
                PaymentType = paymentDto.PaymentType,
                UserId = userId
            };

            await _paymentRepository.AddAsync(payment);
            return await _paymentRepository.SaveChangesAsync();
        }
    }
}
