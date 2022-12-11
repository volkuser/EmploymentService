using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using EmployeeApp.ViewModels.Coordinator;
using PropertyChanged;
using ReactiveUI;

namespace EmployeeApp.Views.Coordinator;

[DoNotNotify]
public partial class JobApplicationControlPage : ReactiveUserControl<JobApplicationControlViewModel>
{
    public JobApplicationControlPage()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}