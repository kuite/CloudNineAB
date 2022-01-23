using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkSampleAB.Application.Music.Model;
using WorkSampleAB.ExternalDataProvider.Model;

namespace WorkSampleAB.Application.Music.Services
{
    public class RecommendationDtoFactory : IRecommendationDtoFactory
    {
        public RecommendationDto Create(Recommendation model)
        {
            return new RecommendationDto
            {
                Tracks = model.tracks.Select(x => new TrackDto
                {
                    Name = x.name,
                    Preview_url = x.preview_url,
                    Type = x.type,
                    Uri = x.uri,
                    Artists = x.artists.Select(y => new ArtistDto
                    {
                        Name = y.name,
                        Type = y.type,
                        Uri = y.uri
                    }).ToList()
                }).ToList()
            };
        }
    }
}
