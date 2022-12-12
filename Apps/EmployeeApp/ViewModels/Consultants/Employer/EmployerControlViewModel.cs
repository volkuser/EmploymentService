using Entities;
using ReactiveUI;
using Splat;

namespace EmployeeApp.ViewModels.Consultants.Employer;

public class EmployerControlViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "employerControl";
    public IScreen? HostScreen { get; }
    private Db Db { get; set; }
    
    

    public EmployerControlViewModel(IPageNavigation container, IScreen? screen)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = DbInstance.GetInstance();
        
        
    }
}