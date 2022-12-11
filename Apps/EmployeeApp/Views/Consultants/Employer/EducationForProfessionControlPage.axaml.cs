using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using EmployeeApp.ViewModels.Consultants.Employer;
using PropertyChanged;
using ReactiveUI;

namespace EmployeeApp.Views.Consultants.Employer;

[DoNotNotify]
public partial class EducationForProfessionControlPage : ReactiveUserControl<EducationForProfessionControlViewModel>
{
    public EducationForProfessionControlPage()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}    