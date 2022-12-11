using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using EmployeeApp.ViewModels.HR;
using PropertyChanged;
using ReactiveUI;

namespace EmployeeApp.Views.HR;

[DoNotNotify]
public partial class EmployeePositionControlPage : ReactiveUserControl<EmployeePositionControlViewModel>
{
    public EmployeePositionControlPage()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}