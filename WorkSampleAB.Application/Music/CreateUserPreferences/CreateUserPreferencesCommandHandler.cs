using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WorkSampleAB.Application.Music.Model;
using WorkSampleAB.Application.Music.Services;
using WorkSampleAB.Domain.Music;
using WorkSampleAB.DomainLogic.Music;

namespace WorkSampleAB.Application.Music.CreateUserPreferences
{
    public class CreateUserPreferencesCommandHandler : IRequestHandler<CreateUserPreferencesCommand, UserPreferencesDto>
    {
        private readonly IUserPreferencesRepository _userPreferencesRepository;
        private readonly IUserPreferencesFactory _userPreferencesFactory;
        private readonly IUserPreferencesDtoFactory _userPreferencesDtoFactory;

        public CreateUserPreferencesCommandHandler(
            IUserPreferencesRepository userPreferencesRepository, 
            IUserPreferencesFactory userPreferencesFactory, 
            IUserPreferencesDtoFactory userPreferencesDtoFactory)
        {
            _userPreferencesRepository = userPreferencesRepository;
            _userPreferencesFactory = userPreferencesFactory;
            _userPreferencesDtoFactory = userPreferencesDtoFactory;
        }

        public async Task<UserPreferencesDto> Handle(CreateUserPreferencesCommand request, CancellationToken cancellationToken)
        {
            var preferences =
                _userPreferencesFactory.Create(request.UserId, request.Artists, request.Genres, request.Songs);
            var createdPreferences = await _userPreferencesRepository.Create(preferences);
            var dto = _userPreferencesDtoFactory.Create(createdPreferences);
            return dto;

        }
    }
}
