using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;
using EmployeeApp.ViewModels;

namespace EmployeeApp.Views;

[DoNotNotify]
public partial class AuthorizationPage : ReactiveUserControl<AuthorizationViewModel>
{
    public AuthorizationPage()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}