using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Input;
using Entities.Models;
using ReactiveUI;

namespace EmployeeApp.ViewModels;

public class MainWindowViewModel : ReactiveObject, IScreen, IPageNavigation
{
    [DataMember] public RoutingState Router { get; set; } = new();

    // commands
    private ICommand OnClickBtnBack { get; set; }
    
    // properties of element on view
    private bool VisibleBtnBack { get; set; }
    private List<bool> VisibilityBtnBackHistory { get; set; } = new();
    
    public MainWindowViewModel()
    {
        DbInstance.GetInstance();
        OpnAuthorizationPage();

        OnClickBtnBack = ReactiveCommand.Create(Back);
    }
    
    public void OpnAuthorizationPage()
    {
        var viewModel = new AuthorizationViewModel(this);
        Router.Navigate.Execute(viewModel);
        AdditionForBtnBackViewHistory(false);
    }
    
    public void OpnMainMenuPage(Employee currentUser)
    {
        var viewModel = new MainMenuViewModel(currentUser, this);
        Router.Navigate.Execute(viewModel);
        AdditionForBtnBackViewHistory(false);
    }
    
    // for HR
    
    public void OpnEmployeeControlPage()
    {
        throw new System.NotImplementedException();
    }

    public void OpnPositionControlPage()
    {
        throw new System.NotImplementedException();
    }

    public void OpnEmployeePositionControlPage()
    {
        throw new System.NotImplementedException();
    }
    
    // for coordinator
    
    public void OpnJobApplicationControlPage()
    {
        throw new System.NotImplementedException();
    }

    // for consultants
    
    // (employed)
    
    public void OpnEmployedControlPage()
    {
        throw new System.NotImplementedException();
    }
    
    public void OpnEmployedEducationControlPage()
    {
        throw new System.NotImplementedException();
    }
    
    // (employer)

    public void OpnEmployerControlPage()
    {
        throw new System.NotImplementedException();
    }

    public void OpnProfessionControlPage()
    {
        throw new System.NotImplementedException();
    }

    public void OpnVacancyControlPage()
    {
        throw new System.NotImplementedException();
    }

    public void OpnEducationForProfessionControlPage()
    {
        throw new System.NotImplementedException();
    }
    
    // for return to back
    
    private void Back()
    {
        Router.NavigateBack.Execute();
        VisibilityBtnBackHistory.RemoveAt(VisibilityBtnBackHistory.Count - 1);
        SetVisibleBtnBack(VisibilityBtnBackHistory[^1]);
    }
    
    private void AdditionForBtnBackViewHistory(bool visibleBtnBack)
    {
        VisibilityBtnBackHistory.Add(visibleBtnBack);
        SetVisibleBtnBack(visibleBtnBack);
    }
    
    private void SetVisibleBtnBack(bool visible) => VisibleBtnBack = visible;
}