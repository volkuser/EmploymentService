using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Entities;
using Entities.Models;
using ReactiveUI;
using Splat;

namespace EmployeeApp.ViewModels.Coordinator;

public class JobApplicationControlViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "jobApplicationControl";
    public IScreen? HostScreen { get; }
    private Db Db { get; set; }
    
    // ui

    private ICommand? OnClickBtnInsert { get; set; }
    private ICommand? OnClickBtnDelete { get; set; }
    
    // logic
    
    private ObservableCollection<JobApplication> JobApplications { get; set; }
    private List<Employed> Employeds { get; set; }
    private List<Vacancy> Vacancies { get; set; }
    private List<Employee> Employees { get; set; }
    
    // in parts
    private Employed Employed { get; set; }
    private Vacancy Vacancy { get; set; }
    private Employee Employee { get; set; }
    // whole
    private JobApplication _selectedValue;
    private JobApplication SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;

            if (value == null) return;
            Employed = value.Employed!;
            Vacancy = value.Vacancy!;
            Employee = value.Employee!;
        }
    }
    
    public JobApplicationControlViewModel(IPageNavigation container, IScreen? screen)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = DbInstance.GetInstance();
        
        JobApplications = new ObservableCollection<JobApplication>(Db.JobApplications!);
        
        Employeds = new List<Employed>(Db.Employeds!);
        Vacancies = new List<Vacancy>(Db.Vacancies!);
        Employees = new List<Employee>(Db.Employees!);
        
        OnClickBtnInsert = ReactiveCommand.Create(Insert);
        OnClickBtnDelete = ReactiveCommand.Create(Delete);
    }
    
    private void Insert()
    {
        var inserting = new JobApplication()
        {
            Employed = Employed,
            Vacancy = Vacancy,
            Employee = Employee
        };
        JobApplications.Add(inserting);
        Db.JobApplications!.Add(inserting);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }

    private void Delete()
    {
        Db.JobApplications!.Remove(SelectedValue);
        try
        {
            Db.SaveChanges(); 
            JobApplications.Remove(SelectedValue);
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }
}