using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Input;
using EmployeeApp.ViewModels.Consultants.Employed;
using EmployeeApp.ViewModels.Consultants.Employer;
using EmployeeApp.ViewModels.Coordinator;
using EmployeeApp.ViewModels.HR;
using Entities.Models;
using ReactiveUI;

namespace EmployeeApp.ViewModels;

public class MainWindowViewModel : ReactiveObject, IScreen, IPageNavigation
{
    [DataMember] public RoutingState Router { get; set; } = new();

    // commands
    private ICommand OnClickBtnBack { get; set; }
    private ICommand OnClickBtnLogout { get; set; }
        
    // properties of element on view
    private bool VisibleBtnBack { get; set; }
    private bool VisibleBtnLogout { get; set; }
    private List<bool> VisibilityBtnBackHistory { get; set; } = new();
    private List<bool> VisibilityBtnLogoutHistory { get; set; } = new();
    
    public MainWindowViewModel()
    {
        DbInstance.GetInstance();
        OpnAuthorizationPage();

        OnClickBtnBack = ReactiveCommand.Create(Back);
        OnClickBtnLogout = ReactiveCommand.Create(OpnAuthorizationPage);
    }
    
    // for all
    
    private void OpnAuthorizationPage()
    {
        var viewModel = new AuthorizationViewModel(this, this);
        Router.Navigate.Execute(viewModel);
        AdditionForHistory(false);
    }
    
    // for employees
    
    public void OpnMainMenuPage(Employee currentUser)
    {
        var viewModel = new MainMenuViewModel(currentUser, this, this);
        Router.Navigate.Execute(viewModel);
        AdditionForHistory(false, true);
    }
    
    // for HR
    
    public void OpnEmployeeControlPage()
    {
        var viewModel = new EmployeeControlViewModel(this, this);
        Router.Navigate.Execute(viewModel);
        AdditionForHistory(true, true);
    }

    public void OpnPositionControlPage()
    {
        var viewModel = new PositionControlViewModel(this, this);
        Router.Navigate.Execute(viewModel);
        AdditionForHistory(true, true);
    }

    public void OpnEmployeePositionControlPage(Employee currentEmployee)
    {
        var viewModel = new EmployeePositionControlViewModel(currentEmployee, this, this);
        Router.Navigate.Execute(viewModel);
        AdditionForHistory(true, false);
    }
    
    // for coordinator
    
    public void OpnJobApplicationControlPage()
    {
        var viewModel = new JobApplicationControlViewModel(this, this);
        Router.Navigate.Execute(viewModel);
        AdditionForHistory(true, true);
    }

    // for consultants
    
    // (employed)
    
    public void OpnEmployedControlPage()
    {
        var viewModel = new EmployedControlViewModel(this, this);
        Router.Navigate.Execute(viewModel);
        AdditionForHistory(true, true);
    }
    
    public void OpnEmployedEducationControlPage(Employed currentEmployed)
    {
        var viewModel = new EmployedEducationControlViewModel(currentEmployed, this, this);
        Router.Navigate.Execute(viewModel);
        AdditionForHistory(true, false);
    }
    
    // (employer)

    public void OpnEmployerControlPage()
    {
        var viewModel = new EmployerControlViewModel(this, this);
        Router.Navigate.Execute(viewModel);
        AdditionForHistory(true, true);
    }

    public void OpnProfessionControlPage()
    {
        var viewModel = new ProfessionControlViewModel(this, this);
        Router.Navigate.Execute(viewModel);
        AdditionForHistory(true, true);
    }

    public void OpnVacancyControlPage()
    {
        var viewModel = new VacancyControlViewModel(this, this);
        Router.Navigate.Execute(viewModel);
        AdditionForHistory(true, true);
    }

    public void OpnEducationForProfessionControlPage(Profession currentProfession)
    {
        var viewModel = new EducationForProfessionControlViewModel(currentProfession, this, this);
        Router.Navigate.Execute(viewModel);
        AdditionForHistory(true, false);
    }
    
    // for return to back and logout
    
    private void Back()
    {
        Router.NavigateBack.Execute();
        SetVisibleBtnBack(GetLastVisibleBtnBackHistory());
        SetVisibleBtnLogout(GetLastVisibleBtnLogoutHistory());
    }

    private void AdditionForHistory(bool visibleBtnBack, bool visibleBtnLogout = false)
    {
        VisibilityBtnBackHistory.Add(visibleBtnBack);
        SetVisibleBtnBack(visibleBtnBack);
        VisibilityBtnLogoutHistory.Add(visibleBtnLogout);
        SetVisibleBtnLogout(visibleBtnLogout);
    }
    private bool GetLastVisibleBtnBackHistory()
    {
        VisibilityBtnBackHistory.RemoveAt(VisibilityBtnBackHistory.Count - 1);
        return VisibilityBtnBackHistory[^1];
    }
    private bool GetLastVisibleBtnLogoutHistory()
    {
        VisibilityBtnLogoutHistory.RemoveAt(VisibilityBtnLogoutHistory.Count - 1);
        return VisibilityBtnLogoutHistory[^1];
    }
    private void SetVisibleBtnBack(bool visible)
    {
        VisibleBtnBack = visible; 
    }
    private void SetVisibleBtnLogout(bool visible)
    {
        VisibleBtnLogout = visible; 
    }
}