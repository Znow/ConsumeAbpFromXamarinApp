using ConsumeAbpFromXamarinApp.Services.Http;
using ConsumeAbpFromXamarinApp.Services.Identity;
using Xamarin.Forms;

namespace ConsumeAbpFromXamarinApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            DependencyService.Register<IdentityService>();
            DependencyService.Register<HttpClientService<IdentityUserDto, IdentityUserDto>>();
            DependencyService.Register<HttpClientService<IdentityDto, IdentityDto>>();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
