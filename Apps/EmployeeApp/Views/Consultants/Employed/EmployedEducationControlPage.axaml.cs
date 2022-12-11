using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using EmployeeApp.ViewModels.Consultants.Employed;
using PropertyChanged;
using ReactiveUI;

namespace EmployeeApp.Views.Consultants.Employed;

[DoNotNotify]
public partial class EmployedEducationControlPage : ReactiveUserControl<EmployedEducationControlViewModel>
{
    public EmployedEducationControlPage()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}