using UserApp.Models;

namespace UserApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ApplicationContext db = Singleton.GetInstance();
        public string Greeting => "Welcome to Avalonia!";
    }
}