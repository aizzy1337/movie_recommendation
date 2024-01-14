using MovieRecomendation.Models;
using MovieRecomendation.Services;

namespace MovieRecomendation;

public partial class ListPage : ContentPage
{
    private readonly IMovieService _movieService;
    List<Movie> recommendedMovies;

    public ListPage(IMovieService movieService)
	{
		InitializeComponent();

        _movieService = movieService;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        recommendedMovies = await _movieService.GetMoviesAsync();

        recommendedMovies.ForEach(movie => movie.poster_path = "https://image.tmdb.org/t/p/w500/" + movie.poster_path);

        collectionView.ItemsSource = recommendedMovies;
    }

    private async void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var navigationParameter = new Dictionary<string, object>
            {
                { nameof(Movie), e.CurrentSelection.FirstOrDefault() as Movie }
            };

        await Shell.Current.GoToAsync(nameof(MovieDetails), navigationParameter);
    }
}