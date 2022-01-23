using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WorkSampleAB.ExternalDataProvider.Model;
using WorkSampleAB.ExternalDataProvider.Services.Interfaces;

namespace WorkSampleAB.ExternalDataProvider.Services
{
    public class TokenHandler : ITokenHandler
    {
        private SpotifyToken _token;
        private const string SignInUrl = "https://accounts.spotify.com/api/token";
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<SpotifyToken> GetToken()
        {
            if (_token != null)
            {
                return _token;
            }
            var clientId = _configuration["ClientId"]; 
            var clientSecret = _configuration["ClientSecret"];

            var encodedAuthorization = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
            var webRequest = (HttpWebRequest)WebRequest.Create(SignInUrl);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Accept = "application/json";
            webRequest.Headers.Add("Authorization: Basic " + encodedAuthorization);

            var request = "grant_type=client_credentials";
            var reqBytes = Encoding.ASCII.GetBytes(request);
            webRequest.ContentLength = reqBytes.Length;

            var strm = webRequest.GetRequestStream();
            strm.Write(reqBytes, 0, reqBytes.Length);
            strm.Close();

            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
            String json = "";
            using (Stream respStr = resp.GetResponseStream())
            {
                using (StreamReader rdr = new StreamReader(respStr, Encoding.UTF8))
                {
                    json = await rdr.ReadToEndAsync();
                    rdr.Close();
                }
            }

            _token = JsonSerializer.Deserialize<SpotifyToken>(json);
            return _token;
        }
    }
}
