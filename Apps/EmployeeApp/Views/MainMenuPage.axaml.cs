using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using EmployeeApp.ViewModels;
using PropertyChanged;
using ReactiveUI;

namespace EmployeeApp.Views;

[DoNotNotify]
public partial class MainMenuPage : ReactiveUserControl<MainMenuViewModel>
{
    public MainMenuPage()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}