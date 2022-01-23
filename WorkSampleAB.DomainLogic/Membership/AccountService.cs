using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using WorkSampleAB.Domain.Membership;

namespace WorkSampleAB.DomainLogic.Membership
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AccountService(
            IUserRepository userRepository, 
            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        
        public async Task<User> GetByLoginCredentials(string userEmail, string password)
        {
            var user = await _userRepository.GetByEmailAsync(userEmail);
            if (user == null)
            {
                throw new Exception("User does not exist.");
            }

            var isPasswordCorrect = IsPasswordCorrect(user, password);
            if (isPasswordCorrect == false)
            {
                throw new Exception("Wrong email or password exception");
            }

            return user;
        }

        public bool IsPasswordCorrect(User user, string password)
        {
            var passwordHash = user.PasswordHash;
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var appSecret = _configuration["Secret"];
            var key = Encoding.ASCII.GetBytes(appSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
