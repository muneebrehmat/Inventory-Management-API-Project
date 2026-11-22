using InventoryManagement_API.Data;
using InventoryManagement_API.DTOS.AuthDTOS;
using InventoryManagement_API.Helpers;
using InventoryManagement_API.Models;
using InventoryManagement_API.Repositries.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement_API.Repositries.Implementation
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly JwtServices _jwtServices;

        public AuthRepository(ApplicationDbContext dbContext,JwtServices jwtServices)
        {
            _dbContext = dbContext;
            _jwtServices = jwtServices;
        }
        public async Task<string> CreateUserAsync(RegistrationDto registrationDto)
        {
            var ExistingUsername = await _dbContext.Users.AnyAsync(u=>u.Username==registrationDto.Username);
            if (ExistingUsername)
            {
                throw new InvalidOperationException("User already exists.");
            }
            var ExistingEmail = await _dbContext.Users.AnyAsync(u=>u.Email==registrationDto.Email);
            if (ExistingEmail)
            {
                throw new InvalidOperationException("Email already exists.");
            }

            var user = new User
            {
                Username = registrationDto.Username,
                Email = registrationDto.Email,
                PasswordHash = registrationDto.Password,
                Role = "Cashier"
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return "User created successfully.";
        }

        public async Task<string> LoginUserAsync(LoginDto loginDto)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(
                u=>u.Username==loginDto.Username&&u.PasswordHash==loginDto.Password);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }
            var token = await _jwtServices.GenerateTokenAsync(user);
            return token;
        }
    }
}
