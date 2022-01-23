using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSampleAB.Application.Music.Model
{
    public class TrackDto
    {
        public string Name { get; set; }
        public string Preview_url { get; set; }
        public List<ArtistDto> Artists { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}
