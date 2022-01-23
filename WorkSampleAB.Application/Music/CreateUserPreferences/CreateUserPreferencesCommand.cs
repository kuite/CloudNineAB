using MediatR;
using WorkSampleAB.Application.Music.Model;

namespace WorkSampleAB.Application.Music.CreateUserPreferences
{
    public class CreateUserPreferencesCommand : IRequest<UserPreferencesDto>
    {
        public int UserId { get; set; }
        public string Genres { get; set; }
        public string Artists { get; set; }
        public string Songs { get; set; }

        public CreateUserPreferencesCommand(int userId, string artists, string genres, string songs)
        {
            UserId = userId;
            Genres = genres;
            Artists = artists;
            Songs = songs;
        }
    }
}
