using System;
using System.Collections.Generic;
using System.Text;
using WorkSampleAB.Domain.Music;

namespace WorkSampleAB.DomainLogic.Music
{
    public class UserPreferencesFactory : IUserPreferencesFactory
    {
        public UserPreferences Create(int userId, string artists, string genres, string songs)
        {
            return new UserPreferences
            {
                UserId = userId,
                Artists = artists,
                Genres = genres,
                Songs = songs
            };
        }
    }
}
