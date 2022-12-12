using Entities;
using Entities.Models;
using ReactiveUI;
using Splat;

namespace EmployeeApp.ViewModels.HR;

public class EmployeePositionControlViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "employeePositionControl";
    public IScreen? HostScreen { get; }
    private Db Db { get; set; }



    public EmployeePositionControlViewModel(Employee currentEmployee, IPageNavigation container, IScreen? screen)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = DbInstance.GetInstance();

        
    }
}