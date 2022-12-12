using Entities.Models;

namespace EmployeeApp.ViewModels;

public interface IPageNavigation
{
    public void OpnMainMenuPage(Employee currentUser);
    
    public void OpnEmployeeControlPage();
    public void OpnPositionControlPage();
    public void OpnEmployeePositionControlPage(Employee currentEmployee);
    public void OpnEmployerControlPage();
    public void OpnProfessionControlPage();
    public void OpnVacancyControlPage();
    public void OpnEmployedControlPage();
    public void OpnEducationForProfessionControlPage(Profession currentProfession);
    public void OpnEmployedEducationControlPage(Employed currentEmployed);
    public void OpnJobApplicationControlPage();
}