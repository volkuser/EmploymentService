using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using EmployeeApp.ViewModels.HR;
using PropertyChanged;
using ReactiveUI;

namespace EmployeeApp.Views.HR;

[DoNotNotify]
public partial class PositionControlPage : ReactiveUserControl<PositionControlViewModel>
{
    public PositionControlPage()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}