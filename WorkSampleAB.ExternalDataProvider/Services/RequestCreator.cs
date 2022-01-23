using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WorkSampleAB.ExternalDataProvider.Model;
using WorkSampleAB.ExternalDataProvider.Services.Interfaces;

namespace WorkSampleAB.ExternalDataProvider.Services
{
    public class RequestCreator : IRequestCreator
    {
        private readonly ITokenHandler _tokenHandler;
        private readonly IApiRouteBuilder _routeBuilder;

        private const string Protocol = "https";
        private const string Address = "api.spotify.com";
        private const string Version = "v1";

        public RequestCreator(
            IApiRouteBuilder routeBuilder, 
            ITokenHandler tokenHandler)
        {
            _routeBuilder = routeBuilder;
            _tokenHandler = tokenHandler;
        }

        public async Task<HttpWebRequest> CreateRecommendationsRequest(params ApiArgument[] arguments)
        {
            var token = await _tokenHandler.GetToken();

            string url = _routeBuilder
                .SetProtocol(Protocol)
                .SetAddress(Address)
                .SetVersion(Version)
                .SetBranch("recommendations")
                .SetArguments(arguments)
                .Build();

            var webRequest = (HttpWebRequest)WebRequest.Create(url);

            webRequest.Method = "GET";
            webRequest.ContentType = "application/json";
            webRequest.Accept = "application/json";
            webRequest.Headers.Add("Authorization: Bearer " + token.access_token);

            return webRequest;
        }
    }
}
