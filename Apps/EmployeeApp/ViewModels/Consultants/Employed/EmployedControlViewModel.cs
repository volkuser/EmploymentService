using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Entities;
using Entities.Models;
using ReactiveUI;
using Splat;

namespace EmployeeApp.ViewModels.Consultants.Employed;

public class EmployedControlViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "employedControl";
    public IScreen? HostScreen { get; }
    private Db Db { get; set; }
    
    // ui

    private ICommand? OnClickBtnInsert { get; set; }
    private ICommand? OnClickBtnDelete { get; set; }
    private ICommand? OnClickBtnUpdate { get; set; }
    private ICommand? OnClickBtnSearch { get; set; }
    
    // logic
    
    private string SearchQuery { get; set; }
    
    private ObservableCollection<Entities.Models.Employed> Employeds { get; set; }
    private List<Sex> Sexes { get; set; }
    
    // in parts
    private string FirstName { get; set; }
    private string LastName { get; set; }
    private string Patronymic { get; set; }
    private string Email { get; set; }
    private string Phone { get; set; }
    private Sex Sex { get; set; }
    // whole
    private Entities.Models.Employed _selectedValue;
    private Entities.Models.Employed SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;

            FirstName = value.FirstName!;
            LastName = value.LastName!;
            Patronymic = value.Patronymic!;
            Email = value.Email!;
            Phone = value.Phone!;
            Sex = value.Sex!;
        }
    }

    public EmployedControlViewModel(IPageNavigation container, IScreen? screen)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = DbInstance.GetInstance();
        
        Employeds = new ObservableCollection<Entities.Models.Employed>(Db.Employeds!);
        foreach (var employed in Employeds)
            employed.CmdEducations = ReactiveCommand.Create(() 
                => container.OpnEmployedEducationControlPage(employed));
        
        Sexes = new List<Sex>(Db.Sexes!);
        
        OnClickBtnInsert = ReactiveCommand.Create(Insert);
        OnClickBtnUpdate = ReactiveCommand.Create(Update);
        OnClickBtnDelete = ReactiveCommand.Create(Delete);
        OnClickBtnSearch = ReactiveCommand.Create(Search);
    }
    
    private void Insert()
    {
        var inserting = new Entities.Models.Employed()
        {
            FirstName = FirstName,
            LastName = LastName,
            Patronymic = Patronymic,
            Email = Email,
            Phone = Phone,
            Sex = Sex,
        };
        Employeds.Add(inserting);
        Db.Employeds!.Add(inserting);
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
        SelectedValue.Patronymic = Patronymic;
        SelectedValue.Email = Email;
        SelectedValue.Phone = Phone;
        SelectedValue.Sex = Sex;
        Db.Employeds!.Update(SelectedValue);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
        
        Employeds.Clear();
        Employeds = new ObservableCollection<Entities.Models.Employed>(Db.Employeds!);
    }

    private void Delete()
    {
        Employeds.Remove(SelectedValue);
        Db.Employeds!.Remove(SelectedValue);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }

    private void Search()
    {
        Employeds.Clear();
        Employeds = new ObservableCollection<Entities.Models.Employed>(Db.Employeds!.Where(x 
            => x.FirstName!.Contains(SearchQuery) || x.LastName!.Contains(SearchQuery) ||
               x.Email!.Contains(SearchQuery) || x.Phone!.Contains(SearchQuery)));
    }
}