using Entities;
using ReactiveUI;
using Splat;

namespace EmployeeApp.ViewModels.Consultants.Employer;

public class VacancyControlViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "vacancyControl";
    public IScreen? HostScreen { get; }
    private Db Db { get; set; }
    
    

    public VacancyControlViewModel(IPageNavigation container, IScreen? screen)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = DbInstance.GetInstance();
        
        
    }
}