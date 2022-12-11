using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Entities;
using Entities.Models;
using ReactiveUI;
using Splat;

namespace EmployeeApp.ViewModels;

public class MainMenuViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "mainMenu";
    public IScreen? HostScreen { get; }
    private Db Db { get; set; }
    
    // show for consultant
    // for employed
    private bool EmployedControlIsVisible { get; set; }
    private ICommand? OnClickBtnEmployedControl { get; set; } // include EmployedEducationControl
    // for employer
    private bool ProfessionControlIsVisible { get; set; }
    private ICommand? OnClickBtnProfessionControl { get; set; } // include EducationForProfessionControl
    private bool EmployerControlIsVisible { get; set; }
    private ICommand? OnClickBtnEmployerControl { get; set; }
    private bool VacancyControlIsVisible { get; set; }
    private ICommand? OnClickBtnVacancyControl { get; set; }
    
    // show for HR
    private bool EmployeeControlIsVisible { get; set; }
    private ICommand? OnClickBtnEmployeeControl { get; set; } // include EmployeePositionControl
    private bool PositionControlIsVisible { get; set; }
    private ICommand? OnClickBtnPositionControl { get; set; }
    
    // show for coordinator 
    private bool JobApplicationIsVisible { get; set; }
    private ICommand? OnClickBtnJobApplicationControl { get; set; }

    public MainMenuViewModel(Employee currentUser, IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = DbInstance.GetInstance();

        EmployedControlIsVisible = ProfessionControlIsVisible = EmployerControlIsVisible = VacancyControlIsVisible =
            EmployeeControlIsVisible = PositionControlIsVisible = JobApplicationIsVisible = false;
        Display(currentUser, container);
    }

    private void Display(Employee currentUser, IPageNavigation container)
    {
        List<Position> currentPositions = new List<Position>();
        foreach (var item in Db.EmployeePositions!.Where(x 
                     => x.EmployeeId.Equals(currentUser.Id)).ToList())
            currentPositions.Add(Db.Positions!.FirstOrDefault(x => x.Id.Equals(item.PositionId))!);

        foreach (var position in currentPositions)
        {
            if (position.Name!.Equals("консультант"))
            {
                EmployedControlIsVisible = true;
                OnClickBtnEmployedControl = ReactiveCommand.Create(container.OpnEmployedControlPage);
            } else if (position.Name!.Equals("регистратор вакансий"))
            {
                ProfessionControlIsVisible = EmployerControlIsVisible = VacancyControlIsVisible = true;
                OnClickBtnProfessionControl = ReactiveCommand.Create(container.OpnProfessionControlPage);
                OnClickBtnEmployerControl = ReactiveCommand.Create(container.OpnEmployerControlPage);
                OnClickBtnVacancyControl = ReactiveCommand.Create(container.OpnVacancyControlPage);
            } else if (position.Name!.Equals("аналитик"))
            {
                JobApplicationIsVisible = true;
                OnClickBtnJobApplicationControl = ReactiveCommand.Create(container.OpnJobApplicationControlPage);
            } else if (position.Name!.Equals("кадровик"))
            {
                EmployeeControlIsVisible = PositionControlIsVisible = true;
                OnClickBtnEmployeeControl = ReactiveCommand.Create(container.OpnEmployeeControlPage);
                OnClickBtnPositionControl = ReactiveCommand.Create(container.OpnPositionControlPage);
            }
        }
    }
}