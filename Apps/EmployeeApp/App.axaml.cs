using Avalonia;
using Avalonia.Markup.Xaml;
using EmployeeApp.ViewModels;
using EmployeeApp.ViewModels.Consultants.Employed;
using EmployeeApp.ViewModels.Consultants.Employer;
using EmployeeApp.ViewModels.Coordinator;
using EmployeeApp.ViewModels.HR;
using EmployeeApp.Views;
using EmployeeApp.Views.Consultants.Employed;
using EmployeeApp.Views.Consultants.Employer;
using EmployeeApp.Views.Coordinator;
using EmployeeApp.Views.HR;
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
            // consultants
            // (employed)
            Locator.CurrentMutable.Register<IViewFor<EmployedControlViewModel>>(() => new EmployedControlPage());
            Locator.CurrentMutable.Register<IViewFor<EmployedEducationControlViewModel>>(() 
                => new EmployedEducationControlPage());
            // (employer)
            Locator.CurrentMutable.Register<IViewFor<EducationForProfessionControlViewModel>>(() 
                => new EducationForProfessionControlPage());
            Locator.CurrentMutable.Register<IViewFor<EmployerControlViewModel>>(() => new EmployerControlPage());
            Locator.CurrentMutable.Register<IViewFor<ProfessionControlViewModel>>(() 
                => new ProfessionControlPage());
            Locator.CurrentMutable.Register<IViewFor<VacancyControlViewModel>>(() => new VacancyControlPage());
            // coordinator
            Locator.CurrentMutable.Register<IViewFor<JobApplicationControlViewModel>>(() 
                => new JobApplicationControlPage());
            // HR
            Locator.CurrentMutable.Register<IViewFor<EmployeeControlViewModel>>(() => new EmployeeControlPage());
            Locator.CurrentMutable.Register<IViewFor<PositionControlViewModel>>(() => new PositionControlPage());
            Locator.CurrentMutable.Register<IViewFor<EmployeePositionControlViewModel>>(() 
                => new EmployeePositionControlPage());
    
            new MainWindow { DataContext = Locator.Current.GetService<IScreen>() }.Show();
            
            base.OnFrameworkInitializationCompleted();
        }
    }
}