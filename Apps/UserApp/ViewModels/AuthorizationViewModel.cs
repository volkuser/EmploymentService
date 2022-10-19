using ReactiveUI;
using Splat;
using UserApp.Models;

namespace UserApp.ViewModels;

public class AuthorizationViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "authorization";
    public IScreen HostScreen { get; }

    private ApplicationContext Db { get; set; }

    public AuthorizationViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
    }
}