using InventoryManagement_API.DTOS.AuthDTOS;

namespace InventoryManagement_API.Repositries.Interfaces
{
    public interface IAuthRepository
    {
        Task<string> CreateUserAsync(RegistrationDto registrationDto);
        Task<string> LoginUserAsync(LoginDto loginDto);
    }
}
