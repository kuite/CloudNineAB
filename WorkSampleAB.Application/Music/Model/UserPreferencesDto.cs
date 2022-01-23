using System.Collections.Generic;

namespace WorkSampleAB.Application.Music.Model
{
    public class UserPreferencesDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public List<string> Genres { get; set; }

        public List<string> Artists { get; set; }

        public List<string> Songs { get; set; }
    }
}
