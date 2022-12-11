using Entities.Models;

namespace EmployeeApp.ViewModels;

public interface IPageNavigation
{
    public void OpnAuthorizationPage();
    public void OpnMainMenuPage(Employee currentUser);
    
    public void OpnEmployeeControlPage();
    public void OpnPositionControlPage();
    public void OpnEmployeePositionControlPage();
    public void OpnEmployerControlPage();
    public void OpnProfessionControlPage();
    public void OpnVacancyControlPage();
    public void OpnEmployedControlPage();
    public void OpnEducationForProfessionControlPage();
    public void OpnEmployedEducationControlPage();
    public void OpnJobApplicationControlPage();
}