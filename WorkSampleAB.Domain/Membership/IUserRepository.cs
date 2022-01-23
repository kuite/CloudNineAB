using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorkSampleAB.Domain.Membership
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);

        Task<User> GetByIdAsync(int id);
    }
}
