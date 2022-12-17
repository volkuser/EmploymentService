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

public class EmployedEducationControlViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "employedEducationControl";
    public IScreen? HostScreen { get; }
    private Db Db { get; set; }
    
    // ui

    private ICommand? OnClickBtnInsert { get; set; }
    private ICommand? OnClickBtnDelete { get; set; }
    
    // logic
    
    private ObservableCollection<EmployedEducation> EmployedEducations { get; set; }
    private List<Education> Educations { get; set; }
    
    // in parts
    private Education Education { get; set; }
    // whole
    private EmployedEducation _selectedValue;
    private EmployedEducation SelectedValue
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

    public EmployedEducationControlViewModel(Entities.Models.Employed currentEmployed, IPageNavigation container, IScreen? screen)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = DbInstance.GetInstance();
        
        EmployedEducations = new ObservableCollection<EmployedEducation>(Db.EmployedEducations!.Where(x 
            => x.EmployedId.Equals(currentEmployed.Id)));
        Educations = new List<Education>(Db.Educations!);
        
        OnClickBtnInsert = ReactiveCommand.Create(() => Insert(currentEmployed));
        OnClickBtnDelete = ReactiveCommand.Create(Delete);
    }
    
    private void Insert(Entities.Models.Employed currentEmployed)
    {
        var inserting = new EmployedEducation()
        {
            Employed = currentEmployed,
            Education = Education
        };
        EmployedEducations.Add(inserting);
        Db.EmployedEducations!.Add(inserting);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }

    private void Delete()
    {
        Db.EmployedEducations!.Remove(SelectedValue);
        try
        {
            Db.SaveChanges(); 
            EmployedEducations.Remove(SelectedValue);
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }
}