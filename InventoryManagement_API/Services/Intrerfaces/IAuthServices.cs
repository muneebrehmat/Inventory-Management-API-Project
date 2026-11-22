using InventoryManagement_API.DTOS.AuthDTOS;

namespace InventoryManagement_API.Services.Intrerfaces
{
    public interface IAuthServices
    {
        Task<string> CreateUserAsync(RegistrationDto registrationDto);
        Task<string> LoginUserAsync(LoginDto loginDto);
    }
}
