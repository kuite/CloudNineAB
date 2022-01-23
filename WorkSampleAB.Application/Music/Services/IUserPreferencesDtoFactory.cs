using WorkSampleAB.Application.Music.Model;
using WorkSampleAB.Domain.Music;

namespace WorkSampleAB.Application.Music.Services
{
    public interface IUserPreferencesDtoFactory
    {
        UserPreferencesDto Create(UserPreferences createdPreferences);
    }
}
