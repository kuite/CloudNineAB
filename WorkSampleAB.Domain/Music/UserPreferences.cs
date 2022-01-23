namespace WorkSampleAB.Domain.Music
{
    public class UserPreferences
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Genres { get; set; }
        public string Artists { get; set; }
        public string Songs { get; set; }
    }
}
