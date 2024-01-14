using MovieRecomendation.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecomendation.Services
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;
        private int number = -1;

        public MovieService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Movie> GetMovieAsync()
        {
            APIResponse apiResponse = await GetAPIResponse();

            List<Movie> result = apiResponse.results.Take(10).ToList();

            if (number == -1)
            {
                Random random = new Random();
                number = random.Next(10);
            }

            return result[number];
        }

        public async Task<List<Movie>> GetMoviesAsync()
        {
            APIResponse apiResponse = await GetAPIResponse();

            return apiResponse.results.Take(10).ToList();
        }

        private async Task<APIResponse> GetAPIResponse()
        {
            var options = new RestClientOptions("https://api.themoviedb.org/3/movie/popular?language=pl-PL&page=1");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", "");
            var response = await client.GetAsync(request);

            APIResponse movieAPIResponse = JsonConvert.DeserializeObject<APIResponse>(response.Content.ToString());

            return movieAPIResponse;
        }

    }
}
