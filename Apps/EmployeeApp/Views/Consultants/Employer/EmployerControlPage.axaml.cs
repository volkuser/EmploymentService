using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using EmployeeApp.ViewModels.Consultants.Employer;
using PropertyChanged;
using ReactiveUI;

namespace EmployeeApp.Views.Consultants.Employer;

[DoNotNotify]
public partial class EmployerControlPage : ReactiveUserControl<EmployerControlViewModel>
{
    public EmployerControlPage()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}