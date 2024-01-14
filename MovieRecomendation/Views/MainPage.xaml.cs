using MovieRecomendation.Models;
using MovieRecomendation.Services;

namespace MovieRecomendation
{
    public partial class MainPage : ContentPage
    {
        private readonly IMovieService _movieService;
        Movie recommendedMovie;

        public MainPage(IMovieService movieService)
        {
            InitializeComponent();

            _movieService = movieService;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            recommendedMovie = await _movieService.GetMovieAsync();
            recommendedMovie.poster_path = "https://image.tmdb.org/t/p/w500/" + recommendedMovie.poster_path;

            movieTitle.Text = recommendedMovie.original_title;
            moviePoster.Source = recommendedMovie.poster_path;
        }

        async void OnClick_SeeDetails(object sender, EventArgs e)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(Movie), recommendedMovie as Movie }
            };

            await Shell.Current.GoToAsync(nameof(MovieDetails), navigationParameter);
        }

    }
}