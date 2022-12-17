using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Entities;
using Entities.Models;
using ReactiveUI;
using Splat;

namespace EmployeeApp.ViewModels.Consultants.Employer;

public class VacancyControlViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "vacancyControl";
    public IScreen? HostScreen { get; }
    private Db Db { get; set; }
    
    // ui

    private ICommand? OnClickBtnInsert { get; set; }
    private ICommand? OnClickBtnDelete { get; set; }
    private ICommand? OnClickBtnUpdate { get; set; }
    
    // logic
    
    private ObservableCollection<Vacancy> Vacancies { get; set; }
    private List<Entities.Models.Employer> Employers { get; set; }
    private List<Profession> Professions { get; set; }
    
    // in parts
    private int Seniority { get; set; }
    private Entities.Models.Employer Employer { get; set; }
    private Profession Profession { get; set; }
    // whole
    private Vacancy _selectedValue;
    private Vacancy SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;

            if (value == null) return;
            Seniority = value.Seniority!;
            Employer = value.Employer!;
            Profession = value.Profession!;
        }
    }

    public VacancyControlViewModel(IPageNavigation container, IScreen? screen)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = DbInstance.GetInstance();
        
        Vacancies = new ObservableCollection<Vacancy>(Db.Vacancies!);
        
        Employers = new List<Entities.Models.Employer>(Db.Employers!);
        Professions = new List<Profession>(Db.Professions!);
        
        OnClickBtnInsert = ReactiveCommand.Create(Insert);
        OnClickBtnUpdate = ReactiveCommand.Create(Update);
        OnClickBtnDelete = ReactiveCommand.Create(Delete);
    }
    
    private void Insert()
    {
        var inserting = new Vacancy()
        {
            Seniority = Seniority,
            Employer = Employer,
            Profession = Profession
        };
        Vacancies.Add(inserting);
        Db.Vacancies!.Add(inserting);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }
    
    private void Update()
    {
        SelectedValue.Seniority = Seniority;
        SelectedValue.Employer = Employer;
        SelectedValue.Profession = Profession;
        Db.Vacancies!.Update(SelectedValue);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
        
        Vacancies.Clear();
        Vacancies = new ObservableCollection<Vacancy>(Db.Vacancies!);
    }

    private void Delete()
    {
        Db.Vacancies!.Remove(SelectedValue);
        try
        {
            Db.SaveChanges(); 
            Vacancies.Remove(SelectedValue);
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }
}