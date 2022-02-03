using System.Threading.Tasks;
using ConsumeAbpFromXamarinApp.ViewModels;
using ConsumeAbpFromXamarinApp.Services.Identity;
using Xamarin.Forms;

namespace ConsumeAbpFromXamarinApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        
        private string _userName;
        private string _password;
        private bool _loading;
        
        IIdentityService IdentityService => DependencyService.Get<IIdentityService>();
        
        public Command LoginCommand { get; }

        public MainViewModel()
        {
            LoginCommand = new Command(async () => await OnLoginClicked());
        }
        
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        
        private async Task OnLoginClicked()
        {
            var loginResult = await IdentityService.LoginAsync(UserName, Password);
            if (!loginResult)
            {
                return;
            }

            // await Shell.Current.GoToAsync($"//{nameof(StartPage)}");
        }
    }
}