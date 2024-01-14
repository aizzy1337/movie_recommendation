using MovieRecomendation.Models;
using MovieRecomendation.Services;

namespace MovieRecomendation;

[QueryProperty(nameof(Movie), "Movie")]
public partial class MovieDetails : ContentPage
{
    private readonly IMovieService _movieService;
    Movie _movie;

    public Movie Movie
    {
        get => _movie;
        set
        {
            _movie = value;
            Title = _movie.original_title;
            OnPropertyChanged();
        }
    }

    public MovieDetails(IMovieService movieService)
	{
		InitializeComponent();

        _movieService = movieService;
        BindingContext = this;
	}
}