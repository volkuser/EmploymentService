using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using EmployeeApp.ViewModels;
using EmployeeApp.Views;
using PropertyChanged;
using ReactiveUI;
using Splat;

namespace EmployeeApp
{
    [DoNotNotify]
    public partial class App : Application
    {
        public override void Initialize() => AvaloniaXamlLoader.Load(this);

        public override void OnFrameworkInitializationCompleted()
        {
            Locator.CurrentMutable.RegisterConstant<IScreen>(new MainWindowViewModel());
            Locator.CurrentMutable.Register<IViewFor<AuthorizationViewModel>>(() => new AuthorizationPage());
            Locator.CurrentMutable.Register<IViewFor<MainMenuViewModel>>(() => new MainMenuPage());
    
            new MainWindow { DataContext = Locator.Current.GetService<IScreen>() }.Show();
            
            base.OnFrameworkInitializationCompleted();
        }
    }
}