using System.Net.Http;
using System.Reflection;
using System.Text;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorkSampleAB.Application.Membership.GetToken;
using WorkSampleAB.Application.Music;
using WorkSampleAB.Application.Music.CreateUserPreferences;
using WorkSampleAB.Application.Music.GetUserRecommendations;
using WorkSampleAB.Application.Music.Model;
using WorkSampleAB.Application.Music.Services;
using WorkSampleAB.Domain.Membership;
using WorkSampleAB.Domain.Music;
using WorkSampleAB.DomainLogic.Membership;
using WorkSampleAB.DomainLogic.Music;
using WorkSampleAB.ExternalDataProvider;
using WorkSampleAB.ExternalDataProvider.Services;
using WorkSampleAB.ExternalDataProvider.Services.Interfaces;
using WorkSampleAB.Infrastructure.Persistence.Database;
using WorkSampleAB.Infrastructure.Persistence.Membership;
using WorkSampleAB.Infrastructure.Persistence.UserPreference;

namespace WorkSampleAB.WebApi.DependencyResolve
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiCompositionRoot(
            this IServiceCollection services)
            => services
                .AddDbContexts()
                .AddQueryHandlers()
                .AddApplicationServices()
                .AddDomainServices()
                .AddExternalDataProviderServices()
                .AddInfrastructuralServices();

        public static IServiceCollection AddDbContexts(
            this IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("InMemoryDatabase"));
            return services;
        }

        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            services.AddScoped<IUserPreferencesDtoFactory, UserPreferencesDtoFactory>();
            services.AddScoped<IRecommendationDtoFactory, RecommendationDtoFactory>();

            return services;
        }

        public static IServiceCollection AddExternalDataProviderServices(
            this IServiceCollection services)
        {
            services.AddScoped<HttpClient>();
            services.AddScoped<StringBuilder>();
            services.AddScoped<ISpotifyWrapper, SpotifyWrapper>();
            services.AddScoped<IRequestCreator, RequestCreator>();
            services.AddScoped<IApiRouteBuilder, ApiRouteBuilder>(); 
            services.AddScoped<IApiArgumentFactory, ApiArgumentFactory>();
            services.AddSingleton<ITokenHandler, TokenHandler>();

            return services;
        }

        public static IServiceCollection AddDomainServices(
            this IServiceCollection services)
        {
            services.AddScoped<IUserPreferencesFactory, UserPreferencesFactory>();

            return services;
        }

        public static IServiceCollection AddInfrastructuralServices(
            this IServiceCollection services)
        {
            //services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserPreferencesRepository, UserPreferencesRepository>();
            //services.AddScoped<ICompanyDetailsRepository, CompanyDetailsRepository>();
            //services.AddScoped<ICompanyFinancialRatiosRepository, CompanyFinancialRatiosRepository>();
            //services.AddScoped<ICompanyIncomeRepository, CompanyIncomeRepository>();
            //services.AddScoped<ICompanyShortDataRepository, CompanyShortDataRepository>();
            //services.AddScoped<ICompanyFullDataRepository, CompanyFullDataRepository>();

            return services;
        }

        public static IServiceCollection AddQueryHandlers(
            this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            //services.AddScoped<ICompanyDetailsDtoFactory, CompanyDetailsDtoFactory>();
            //services.AddScoped<ICompanyShortDataDtoFactory, CompanyShortDataDtoFactory>();
            //services.AddScoped<ICompanyFullDataDtoFactory, CompanyFullDataDtoFactory>();

            //services.AddScoped<IRequestHandler<CreateAccountCommand, UserCreatedDto>, CreateAccountCommandHandler>();
            services.AddScoped<IRequestHandler<GetTokenQuery, string>, GetTokenQueryHandler>();
            services.AddScoped<IRequestHandler<CreateUserPreferencesCommand, UserPreferencesDto>, CreateUserPreferencesCommandHandler>();
            services.AddScoped<IRequestHandler<GetUserRecommendationsQuery, RecommendationDto>, GetUserRecommendationsQueryHandler>();
            //services.AddScoped<IRequestHandler<GetCompanyDetailsQuery, CompanyDetailsDto>, GetCompanyDetailsQueryHandler>();
            //services.AddScoped<IRequestHandler<GetCompanyDetailsByTickerQuery, CompanyDetailsDto>, GetCompanyDetailsByTickerQueryHandler>();

            return services;
        }

    }
}
