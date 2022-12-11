using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using EmployeeApp.ViewModels.Consultants.Employed;
using PropertyChanged;
using ReactiveUI;

namespace EmployeeApp.Views.Consultants.Employed;

[DoNotNotify]
public partial class EmployedControlPage : ReactiveUserControl<EmployedControlViewModel>
{
    public EmployedControlPage()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}