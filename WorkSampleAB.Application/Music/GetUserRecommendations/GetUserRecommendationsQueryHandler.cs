using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WorkSampleAB.Application.Music.Model;
using WorkSampleAB.Application.Music.Services;
using WorkSampleAB.Domain.Music;
using WorkSampleAB.ExternalDataProvider;
using WorkSampleAB.ExternalDataProvider.Services.Interfaces;

namespace WorkSampleAB.Application.Music.GetUserRecommendations
{
    public class GetUserRecommendationsQueryHandler : IRequestHandler<GetUserRecommendationsQuery, RecommendationDto>
    {
        private readonly IUserPreferencesRepository _userPreferencesRepository;
        private readonly ISpotifyWrapper _spotifyWrapper;
        private readonly IApiArgumentFactory _argumentFactory;
        private readonly IRecommendationDtoFactory _recommendationDtoFactory;

        public GetUserRecommendationsQueryHandler(
            IUserPreferencesRepository userPreferencesRepository, 
            ISpotifyWrapper spotifyWrapper, 
            IApiArgumentFactory argumentFactory, 
            IRecommendationDtoFactory recommendationDtoFactory)
        {
            _userPreferencesRepository = userPreferencesRepository;
            _spotifyWrapper = spotifyWrapper;
            _argumentFactory = argumentFactory;
            _recommendationDtoFactory = recommendationDtoFactory;
        }

        public async Task<RecommendationDto> Handle(GetUserRecommendationsQuery request, CancellationToken cancellationToken)
        {
            var preferences = await _userPreferencesRepository.GetByUserId(request.UserId);
            var arguments = 
                _argumentFactory.CreateArguments("seed_artists", preferences.Artists)
                    .Concat(_argumentFactory.CreateArguments("seed_genres", preferences.Genres))
                    .Concat(_argumentFactory.CreateArguments("seed_tracks", preferences.Songs))
                    .ToArray();
            var recommendations = await _spotifyWrapper.GetRecommendations(arguments);

            var dtos = _recommendationDtoFactory.Create(recommendations);
            return dtos;
        }
    }
}
