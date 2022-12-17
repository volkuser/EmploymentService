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

public class EducationForProfessionControlViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "educationForProfessionControl";
    public IScreen? HostScreen { get; }
    private Db Db { get; set; }
    
    // ui

    private ICommand? OnClickBtnInsert { get; set; }
    private ICommand? OnClickBtnDelete { get; set; }
    
    // logic
    
    private ObservableCollection<EducationForProfession> EducationsForProfessions { get; set; }
    private List<Education> Educations { get; set; }
    
    // in parts
    private Education Education { get; set; }
    // whole
    private EducationForProfession _selectedValue;
    private EducationForProfession SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;

            if (value == null) return;
            Education = value.Education!;
        }
    }

    public EducationForProfessionControlViewModel(Profession currentProfession, 
        IPageNavigation container, IScreen? screen)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = DbInstance.GetInstance();
        
        EducationsForProfessions = new ObservableCollection<EducationForProfession>(Db.EducationsForProfessions!.Where(x 
            => x.ProfessionId.Equals(currentProfession.Id)));
        Educations = new List<Education>(Db.Educations!);
        
        OnClickBtnInsert = ReactiveCommand.Create(() => Insert(currentProfession));
        OnClickBtnDelete = ReactiveCommand.Create(Delete);
    }
    
    private void Insert(Entities.Models.Profession currentProfession)
    {
        var inserting = new EducationForProfession()
        {
            Profession = currentProfession,
            Education = Education
        };
        EducationsForProfessions.Add(inserting);
        Db.EducationsForProfessions!.Add(inserting);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }

    private void Delete()
    {
        Db.EducationsForProfessions!.Remove(SelectedValue);
        try
        {
            Db.SaveChanges(); 
            EducationsForProfessions.Remove(SelectedValue);
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }
}