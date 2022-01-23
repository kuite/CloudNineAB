using System.Threading.Tasks;

namespace WorkSampleAB.Domain.Music
{
    public interface IUserPreferencesRepository
    {
        Task<UserPreferences> GetByUserId(int id);
        Task<UserPreferences> Create(UserPreferences userPreferences);
        Task<UserPreferences> Update(UserPreferences userPreferences);
    }
}
