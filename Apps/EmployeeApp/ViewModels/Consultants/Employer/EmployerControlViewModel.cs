using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Entities;
using Entities.Models;
using ReactiveUI;
using Splat;

namespace EmployeeApp.ViewModels.Consultants.Employer;

public class EmployerControlViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "employerControl";
    public IScreen? HostScreen { get; }
    private Db Db { get; set; }
    
    // ui

    private ICommand? OnClickBtnInsert { get; set; }
    private ICommand? OnClickBtnDelete { get; set; }
    private ICommand? OnClickBtnUpdate { get; set; }
    private ICommand? OnClickBtnSearch { get; set; }
    
    // logic
    
    private string SearchQuery { get; set; }
    
    private ObservableCollection<Entities.Models.Employer> Employers { get; set; }

    // in parts
    private string FirstName { get; set; }
    private string LastName { get; set; }
    private string Position { get; set; }
    private string PersonalPhone { get; set; }
    private string PersonalEmail { get; set; }
    private string OrganizationName { get; set; }
    private string SupportNumber { get; set; }
    private string SupportEmail { get; set; }
    private string RegistrationAddressOfOrganization { get; set; }
    // whole
    private Entities.Models.Employer _selectedValue;
    private Entities.Models.Employer SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;

            if (value == null) return;
            FirstName = value.FirstName!;
            LastName = value.LastName!;
            Position = value.Position!;
            PersonalPhone = value.PersonalPhone!;
            PersonalEmail = value.PersonalEmail!;
            OrganizationName = value.OrganizationName!;
            SupportNumber = value.SupportNumber!;
            SupportEmail = value.SupportEmail!;
            RegistrationAddressOfOrganization = value.RegistrationAddressOfOrganization!;
        }
    }

    public EmployerControlViewModel(IPageNavigation container, IScreen? screen)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = DbInstance.GetInstance();
        
        Employers = new ObservableCollection<Entities.Models.Employer>(Db.Employers!);
        
        OnClickBtnInsert = ReactiveCommand.Create(Insert);
        OnClickBtnUpdate = ReactiveCommand.Create(Update);
        OnClickBtnDelete = ReactiveCommand.Create(Delete);
        OnClickBtnSearch = ReactiveCommand.Create(Search);
    }
    
    private void Insert()
    {
        var inserting = new Entities.Models.Employer()
        {
            FirstName = FirstName,
            LastName = LastName,
            Position = Position, 
            PersonalPhone = PersonalPhone,
            PersonalEmail = PersonalEmail,
            OrganizationName = OrganizationName,
            SupportNumber = SupportNumber,
            SupportEmail = SupportEmail,
            RegistrationAddressOfOrganization = RegistrationAddressOfOrganization
        };
        Employers.Add(inserting);
        Db.Employers!.Add(inserting);
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
        SelectedValue.Position = Position;
        SelectedValue.PersonalPhone = PersonalPhone;
        SelectedValue.PersonalEmail = PersonalEmail;
        SelectedValue.OrganizationName = OrganizationName;
        SelectedValue.SupportNumber = SupportNumber;
        SelectedValue.SupportEmail = SupportEmail;
        SelectedValue.RegistrationAddressOfOrganization = RegistrationAddressOfOrganization;
        Db.Employers!.Update(SelectedValue);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
        
        Employers.Clear();
        Employers = new ObservableCollection<Entities.Models.Employer>(Db.Employers!);
    }

    private void Delete()
    {
        Db.Employers!.Remove(SelectedValue);
        try
        {
            Db.SaveChanges(); 
            Employers.Remove(SelectedValue);
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }

    private void Search()
    {
        Employers.Clear();
        Employers = new ObservableCollection<Entities.Models.Employer>(Db.Employers!.Where(x 
            => x.OrganizationName!.Contains(SearchQuery) || x.LastName!.Contains(SearchQuery)));
    }
}