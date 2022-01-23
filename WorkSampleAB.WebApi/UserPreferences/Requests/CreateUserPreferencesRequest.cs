using System.ComponentModel.DataAnnotations;

namespace WorkSampleAB.WebApi.UserPreferences.Requests
{
    public class CreateUserPreferencesRequest
    {
        [Required]
        public string Genres { get; set; }
        [Required]
        public string Artists { get; set; }
        [Required]
        public string Songs { get; set; }
    }
}
