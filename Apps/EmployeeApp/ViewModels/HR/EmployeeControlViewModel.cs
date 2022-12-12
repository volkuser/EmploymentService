using Entities;
using ReactiveUI;
using Splat;

namespace EmployeeApp.ViewModels.HR;

public class EmployeeControlViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "employeeControl";
    public IScreen? HostScreen { get; }
    private Db Db { get; set; }



    public EmployeeControlViewModel(IPageNavigation container, IScreen? screen)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = DbInstance.GetInstance();

        
    }
}