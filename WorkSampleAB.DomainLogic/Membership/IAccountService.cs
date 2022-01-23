using System.Threading.Tasks;
using WorkSampleAB.Domain.Membership;

namespace WorkSampleAB.DomainLogic.Membership
{
    public interface IAccountService
    {
        Task<User> GetByLoginCredentials(string userEmail, string password);

        bool IsPasswordCorrect(User user, string password);

        string GenerateToken(User user);
    }
}
