using System.Collections.Generic;
using System.Threading.Tasks;
using WorkSampleAB.ExternalDataProvider.Model;

namespace WorkSampleAB.ExternalDataProvider
{
    public interface ISpotifyWrapper
    {
        Task<Recommendation> GetRecommendations(params ApiArgument[] arguments);
    }
}
