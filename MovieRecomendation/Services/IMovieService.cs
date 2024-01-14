using MovieRecomendation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecomendation.Services
{
    public interface IMovieService
    {
        public Task<Movie> GetMovieAsync();
        public Task<List<Movie>> GetMoviesAsync();
    }
}
