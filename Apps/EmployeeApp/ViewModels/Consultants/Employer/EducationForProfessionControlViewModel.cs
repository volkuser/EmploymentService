using Entities;
using Entities.Models;
using ReactiveUI;
using Splat;

namespace EmployeeApp.ViewModels.Consultants.Employer;

public class EducationForProfessionControlViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "educationForProfessionControl";
    public IScreen? HostScreen { get; }
    private Db Db { get; set; }

    public EducationForProfessionControlViewModel(Profession currentProfession, IPageNavigation container, IScreen? screen)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = DbInstance.GetInstance();
        
        
    }
}