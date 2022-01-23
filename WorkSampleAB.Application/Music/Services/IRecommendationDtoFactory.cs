using System;
using System.Collections.Generic;
using System.Text;
using WorkSampleAB.Application.Music.Model;
using WorkSampleAB.ExternalDataProvider.Model;

namespace WorkSampleAB.Application.Music.Services
{
    public interface IRecommendationDtoFactory
    {
        RecommendationDto Create(Recommendation model);
    }
}
