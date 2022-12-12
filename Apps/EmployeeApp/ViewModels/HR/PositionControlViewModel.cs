using Entities;
using ReactiveUI;
using Splat;

namespace EmployeeApp.ViewModels.HR;

public class PositionControlViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "positionControl";
    public IScreen? HostScreen { get; }
    private Db Db { get; set; }



    public PositionControlViewModel(IPageNavigation container, IScreen? screen)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = DbInstance.GetInstance();

    }
}