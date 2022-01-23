using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using WorkSampleAB.Application.Music.CreateUserPreferences;
using WorkSampleAB.Application.Music.Services;
using WorkSampleAB.Domain.Music;
using WorkSampleAB.DomainLogic.Music;
using Xunit;

namespace WorkSampleAB.Application.Tests.Music.CreateUserPreferences
{
    public class CreateUserPreferencesCommandHandlerPassTests
    {
        [Fact]
        public async Task Handle_WhenCalled_CallCreateUserPreferencesRepository()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            var userId = 1;
            var artists = "artists";
            var genres = "genres";
            var songs = "songs";

            var preferencesRepository = fixture.Freeze<Mock<IUserPreferencesRepository>>();

            var query = fixture.Build<CreateUserPreferencesCommand>()
                .With(x => x.Artists, artists)
                .With(x => x.Genres, genres)
                .With(x => x.Songs, songs)
                .Create();
            var handler = fixture.Create<CreateUserPreferencesCommandHandler>();
            var token = fixture.Create<CancellationToken>();

            // Act
            await handler.Handle(query, token);

            // Assert
            preferencesRepository.Verify(x => x.Create(It.IsAny<UserPreferences>()));
        }

        [Fact]
        public async Task Handle_WhenCalled_CallCreateUserPreferencesDtoFactory()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            var artists = "artists";
            var genres = "genres";
            var songs = "songs";
            var preferencesDtoFactory = fixture.Freeze<Mock<IUserPreferencesDtoFactory>>();

            var query = fixture.Build<CreateUserPreferencesCommand>()
                .With(x => x.Artists, artists)
                .With(x => x.Genres, genres)
                .With(x => x.Songs, songs)
                .Create();
            var handler = fixture.Create<CreateUserPreferencesCommandHandler>();
            var token = fixture.Create<CancellationToken>();

            // Act
            await handler.Handle(query, token);

            // Assert
            preferencesDtoFactory.Verify(x => x.Create(It.IsAny<UserPreferences>()));
        }

        [Fact]
        public async Task Handle_WhenCalled_CallCreateUserPreferencesFactory()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            var artists = "artists";
            var genres = "genres";
            var songs = "songs";
            var preferencesFactory = fixture.Freeze<Mock<IUserPreferencesFactory>>();

            var query = fixture.Build<CreateUserPreferencesCommand>()
                .With(x => x.Artists, artists)
                .With(x => x.Genres, genres)
                .With(x => x.Songs, songs)
                .Create();
            var handler = fixture.Create<CreateUserPreferencesCommandHandler>();
            var token = fixture.Create<CancellationToken>();

            // Act
            await handler.Handle(query, token);

            // Assert
            preferencesFactory.Verify(x => x.Create(It.IsAny<int>(), artists, genres, songs));
        }
    }
}
