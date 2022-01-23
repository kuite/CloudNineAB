using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using WorkSampleAB.Application.Music.Model;

namespace WorkSampleAB.Application.Music.GetUserRecommendations
{
    public class GetUserRecommendationsQuery : IRequest<RecommendationDto>
    {
        public int UserId { get; }

        public GetUserRecommendationsQuery(int id)
        {
            UserId = id;
        }
    }
}
