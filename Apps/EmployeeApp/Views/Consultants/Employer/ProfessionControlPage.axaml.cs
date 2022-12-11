using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using EmployeeApp.ViewModels.Consultants.Employer;
using PropertyChanged;
using ReactiveUI;

namespace EmployeeApp.Views.Consultants.Employer;

[DoNotNotify]
public partial class ProfessionControlPage : ReactiveUserControl<ProfessionControlViewModel>
{
    public ProfessionControlPage()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}