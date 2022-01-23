using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using WorkSampleAB.Application.Music.CreateUserPreferences;
using WorkSampleAB.Application.Music.GetUserRecommendations;
using WorkSampleAB.Domain.Music;
using WorkSampleAB.ExternalDataProvider;
using WorkSampleAB.ExternalDataProvider.Model;
using Xunit;

namespace WorkSampleAB.Application.Tests.Music.GetUserRecommendations
{
    public class GetUserRecommendationsQueryHandlerPassTests
    {
        [Fact]
        public async Task Handle_WhenCalled_CallGeRecommendationSpotifyWrapper()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            var spotifyWrapper = fixture.Freeze<Mock<ISpotifyWrapper>>();

            var query = fixture.Build<GetUserRecommendationsQuery>()
                .Create();
            var handler = fixture.Create<GetUserRecommendationsQueryHandler>();
            var token = fixture.Create<CancellationToken>();

            // Act
            await handler.Handle(query, token);

            // Assert
            spotifyWrapper.Verify(x => x.GetRecommendations(It.IsAny<ApiArgument[]>()));
        }
    }
}
