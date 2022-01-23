using System;
using System.Collections.Generic;
using System.Text;
using WorkSampleAB.Domain.Music;

namespace WorkSampleAB.DomainLogic.Music
{
    public interface IUserPreferencesFactory
    {
        UserPreferences Create(int userId, string artists, string genres, string songs);
    }
}
