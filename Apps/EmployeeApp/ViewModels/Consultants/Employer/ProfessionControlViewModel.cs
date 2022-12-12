using Entities;
using ReactiveUI;
using Splat;

namespace EmployeeApp.ViewModels.Consultants.Employer;

public class ProfessionControlViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "professionControl";
    public IScreen? HostScreen { get; }
    private Db Db { get; set; }
    
    

    public ProfessionControlViewModel(IPageNavigation container, IScreen? screen)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = DbInstance.GetInstance();
        
        
    }
}