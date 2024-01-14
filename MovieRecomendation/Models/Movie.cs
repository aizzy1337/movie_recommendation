using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecomendation.Models
{
    public class APIResponse
    {
        [JsonProperty("results")]
        public List<Movie>? results { get; set; }
    }

    public class Movie
    {
        [JsonProperty("original_title")]
        public string? original_title { get; set; }
        [JsonProperty("overview")]
        public string? overview { get; set; }
        [JsonProperty("poster_path")]
        public string? poster_path { get; set; }
        [JsonProperty("release_date")]
        public string? release_date { get; set; }
        [JsonProperty("vote_average")]
        public double vote_average { get; set; }
        [JsonProperty("vote_count")]
        public int vote_count { get; set; }
    }
}
