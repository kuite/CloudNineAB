using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkSampleAB.Domain.Music;
using WorkSampleAB.Infrastructure.Persistence.Database;

namespace WorkSampleAB.Infrastructure.Persistence.UserPreference
{
    public class UserPreferencesRepository : IUserPreferencesRepository
    {
        private readonly DatabaseContext _context;

        public UserPreferencesRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<UserPreferences> GetByUserId(int id)
        {
            return await _context.UserPreferences.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<UserPreferences> Create(UserPreferences userPreferences)
        {
            _context.UserPreferences.Add(userPreferences);
            await _context.SaveChangesAsync();
            return userPreferences;
        }

        public Task<UserPreferences> Update(UserPreferences userPreferences)
        {
            throw new NotImplementedException();
        }
    }
}
