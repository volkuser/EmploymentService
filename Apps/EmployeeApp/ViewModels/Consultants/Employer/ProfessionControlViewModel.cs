using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Entities;
using Entities.Models;
using ReactiveUI;
using Splat;

namespace EmployeeApp.ViewModels.Consultants.Employer;

public class ProfessionControlViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "professionControl";
    public IScreen? HostScreen { get; }
    private Db Db { get; set; }
    
    // ui

    private ICommand? OnClickBtnInsert { get; set; }
    private ICommand? OnClickBtnDelete { get; set; }
    
    // logic
    
    private string SearchQuery { get; set; }
    
    private ObservableCollection<Profession> Professions { get; set; }

    // in parts
    private string Name { get; set; }
    // whole
    private Profession _selectedValue;
    private Profession SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;

            if (value == null) return;
            Name = value.Name!;
        }
    }

    public ProfessionControlViewModel(IPageNavigation container, IScreen? screen)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = DbInstance.GetInstance();
        
        Professions = new ObservableCollection<Profession>(Db.Professions!);
        foreach (var profession in Professions)
            profession.CmdEducations = ReactiveCommand.Create(() 
                => container.OpnEducationForProfessionControlPage(profession));

        OnClickBtnInsert = ReactiveCommand.Create(Insert);
        OnClickBtnDelete = ReactiveCommand.Create(Delete);
    }
    
    private void Insert()
    {
        var inserting = new Profession()
        {
            Name = Name
        };
        Professions.Add(inserting);
        Db.Professions!.Add(inserting);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }

    private void Delete()
    {
        Db.Professions!.Remove(SelectedValue);
        try
        {
            Db.SaveChanges(); 
            Professions.Remove(SelectedValue);
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }
}