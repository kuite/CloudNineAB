namespace WorkSampleAB.WebApi.Membership.Requests
{
    public class GetTokenRequest
    {
        public string UserEmail { get; set; }

        public string Password { get; set; }
    }
}
