using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Entities;
using Entities.Models;
using ReactiveUI;
using Splat;

namespace EmployeeApp.ViewModels.HR;

public class EmployeeControlViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "employeeControl";
    public IScreen? HostScreen { get; }
    private Db Db { get; set; }

    // ui

    private ICommand? OnClickBtnInsert { get; set; }
    private ICommand? OnClickBtnDelete { get; set; }
    private ICommand? OnClickBtnUpdate { get; set; }
    private ICommand? OnClickBtnSearch { get; set; }
    
    // logic
    
    private string SearchQuery { get; set; }
    
    private ObservableCollection<Employee> Employees { get; set; }
    
    // in parts
    private string FirstName { get; set; }
    private string LastName { get; set; }
    private string Login { get; set; }
    private string Password { get; set; }
    // whole
    private Employee _selectedValue;
    private Employee SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;

            if (value == null) return;
            FirstName = value.FirstName!;
            LastName = value.LastName!;
            Login = value.Login!;
            Password = value.Password!;
        }
    }

    public EmployeeControlViewModel(IPageNavigation container, IScreen? screen)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = DbInstance.GetInstance();

        Employees = new ObservableCollection<Employee>(Db.Employees!);
        foreach (var employee in Employees)
            employee.CmdPositions = ReactiveCommand.Create(() 
                => container.OpnEmployeePositionControlPage(employee));

        OnClickBtnInsert = ReactiveCommand.Create(Insert);
        OnClickBtnUpdate = ReactiveCommand.Create(Update);
        OnClickBtnDelete = ReactiveCommand.Create(Delete);
        OnClickBtnSearch = ReactiveCommand.Create(Search);
    }
    
    private void Insert()
    {
        var inserting = new Employee()
        {
            FirstName = FirstName,
            LastName = LastName,
            Login = Login,
            Password = Password
        };
        Employees.Add(inserting);
        Db.Employees!.Add(inserting);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }

    private void Update()
    {
        SelectedValue.FirstName = FirstName;
        SelectedValue.LastName = LastName;
        SelectedValue.Login = Login;
        SelectedValue.Password = Password;
        Db.Employees!.Update(SelectedValue);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
        
        Employees.Clear();
        Employees = new ObservableCollection<Employee>(Db.Employees!);
    }

    private void Delete()
    {
        Db.Employees!.Remove(SelectedValue);
        try
        {
            Db.SaveChanges(); 
            Employees.Remove(SelectedValue);
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }

    private void Search()
    {
        Employees.Clear();
        Employees = new ObservableCollection<Employee>(Db.Employees!.Where(x 
            => x.FirstName!.Contains(SearchQuery) || x.LastName!.Contains(SearchQuery) ||
               x.Login!.Contains(SearchQuery)));
    }
}