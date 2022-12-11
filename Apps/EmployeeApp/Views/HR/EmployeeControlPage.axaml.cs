using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using EmployeeApp.ViewModels.HR;
using PropertyChanged;
using ReactiveUI;

namespace EmployeeApp.Views.HR;

[DoNotNotify]
public partial class EmployeeControlPage : ReactiveUserControl<EmployeeControlViewModel>
{
    public EmployeeControlPage()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}