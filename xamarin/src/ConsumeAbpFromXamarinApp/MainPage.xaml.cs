using ConsumeAbpFromXamarinApp.ViewModels;
using Xamarin.Forms;

namespace ConsumeAbpFromXamarinApp
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel _viewModel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MainViewModel();
        }
    }
}
