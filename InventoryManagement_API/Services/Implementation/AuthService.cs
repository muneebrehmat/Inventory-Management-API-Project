using InventoryManagement_API.DTOS.AuthDTOS;
using InventoryManagement_API.Repositries.Interfaces;
using InventoryManagement_API.Services.Intrerfaces;

namespace InventoryManagement_API.Services.Implementation
{
    public class AuthService : IAuthServices
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public Task<string> CreateUserAsync(RegistrationDto registrationDto)
        {
           return _authRepository.CreateUserAsync(registrationDto);
        }

        public Task<string> LoginUserAsync(LoginDto loginDto)
        {
            return _authRepository.LoginUserAsync(loginDto);
        }
    }
}
