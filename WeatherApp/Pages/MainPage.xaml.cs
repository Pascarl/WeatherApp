using WeatherApp.Models.ViewModels;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new WeatherAppInfoViewModel();
        }

    }

}
