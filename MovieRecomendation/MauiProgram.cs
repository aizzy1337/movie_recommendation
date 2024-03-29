﻿using Microsoft.Extensions.Logging;
using MovieRecomendation.Services;

namespace MovieRecomendation
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<IMovieService, MovieService>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<ListPage>();
            builder.Services.AddTransient<MovieDetails>();

            return builder.Build();
        }
    }
}