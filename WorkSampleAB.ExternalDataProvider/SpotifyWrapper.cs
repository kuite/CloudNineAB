using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using WorkSampleAB.ExternalDataProvider.Model;
using WorkSampleAB.ExternalDataProvider.Services.Interfaces;

namespace WorkSampleAB.ExternalDataProvider
{
    public class SpotifyWrapper : ISpotifyWrapper
    {
        private readonly IRequestCreator _requestCreator;

        public SpotifyWrapper(IRequestCreator requestCreator)
        {
            _requestCreator = requestCreator;
        }

        public async Task<Recommendation> GetRecommendations(params ApiArgument[] arguments)
        {
            //ApiArgument[] arguments = {
            //    new ApiArgument { Name = "seed_genres", Value = "classical" },
            //    new ApiArgument { Name = "seed_genres", Value = "country" },
            //    new ApiArgument { Name = "seed_tracks", Value = "0c6xIDDpzE81m2q797ordA" },
            //    new ApiArgument { Name = "seed_artists", Value = "4NHQUGzhtTLFvgF5SZesLK" }
            //};
            var request = await _requestCreator.CreateRecommendationsRequest(arguments);

            string recommendationUrl = "limit=10&market=ES&" +
                                       "seed_artists=4NHQUGzhtTLFvgF5SZesLK&" +
                                       "seed_genres=classical%2Ccountry&" +
                                       "seed_tracks=0c6xIDDpzE81m2q797ordA"; 


            var response = request.GetResponse();
            var responseJson = "";
            using (Stream respStr2 = response.GetResponseStream())
            {
                using (StreamReader rdr = new StreamReader(respStr2, Encoding.UTF8))
                {
                    responseJson = rdr.ReadToEnd();
                    rdr.Close();
                }
            }
            return JsonSerializer.Deserialize<Recommendation>(responseJson);
        }
    }
}
