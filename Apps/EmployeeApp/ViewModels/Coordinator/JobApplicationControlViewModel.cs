using Entities;
using ReactiveUI;
using Splat;

namespace EmployeeApp.ViewModels.Coordinator;

public class JobApplicationControlViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "jobApplicationControl";
    public IScreen? HostScreen { get; }
    private Db Db { get; set; }



    public JobApplicationControlViewModel(IPageNavigation container, IScreen? screen)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = DbInstance.GetInstance();

    }
}