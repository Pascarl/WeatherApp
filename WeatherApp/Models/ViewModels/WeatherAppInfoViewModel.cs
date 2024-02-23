using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherApp.Services;

namespace WeatherApp.Models.ViewModels
{
    internal partial class WeatherAppInfoViewModel : ObservableObject
    {

        private readonly WeatherApiService _weatherApiService;

        public WeatherAppInfoViewModel()
        {
            _weatherApiService = new WeatherApiService();
        }

        [ObservableProperty]
        private string latitude;

        [ObservableProperty]
        private string longitude;

        [ObservableProperty]
        private string weatherIcon;

        [ObservableProperty]
        private string temperture;

        [ObservableProperty]
        private string weatherDescription;

        [ObservableProperty]
        private string location;

        [ObservableProperty]
        private int humidity;

        [ObservableProperty]
        private string cloudCoverLevel;

        [ObservableProperty]
        private string isDay;

        [RelayCommand]
        private async Task FetchWeatherInfo()
        {
            var weatherApiRespone = await _weatherApiService.GetWeatherInfomation(Location);
            if(weatherApiRespone != null)
            {
                WeatherIcon = weatherApiRespone.Current.WeatherIcons[0];
                Temperture = $"{weatherApiRespone.Current.Temperature}C";
                Location = $"{weatherApiRespone.Location.Name},{weatherApiRespone.Location.Region},{weatherApiRespone.Location.Country}";
                WeatherDescription = weatherApiRespone.Current.WeatherDescriptions[0];
                Humidity = weatherApiRespone.Current.Humidity;
                CloudCoverLevel = $"{weatherApiRespone.Current.CloudCoverLevel}%";
                IsDay = weatherApiRespone.Current.IsDay.ToUpper();
            }
        }
    }
}
