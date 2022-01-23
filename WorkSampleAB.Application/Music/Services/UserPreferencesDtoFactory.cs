using System.Linq;
using WorkSampleAB.Application.Music.Model;
using WorkSampleAB.Domain.Music;

namespace WorkSampleAB.Application.Music.Services
{
    public class UserPreferencesDtoFactory : IUserPreferencesDtoFactory
    {
        public UserPreferencesDto Create(UserPreferences createdPreferences)
        {
            var genres = createdPreferences.Genres.Split(',').ToList();
            var artists = createdPreferences.Artists.Split(',').ToList();
            var songs = createdPreferences.Songs.Split(',').ToList();
            return new UserPreferencesDto
            {
                Id = createdPreferences.Id,
                UserId = createdPreferences.UserId,
                Genres = genres,
                Songs = songs,
                Artists = artists
            };
        }
    }
}
