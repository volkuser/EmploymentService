using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Entities;
using Entities.Models;
using ReactiveUI;
using Splat;

namespace EmployeeApp.ViewModels.HR;

public class PositionControlViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "positionControl";
    public IScreen? HostScreen { get; }
    private Db Db { get; set; }

    // ui

    private ICommand? OnClickBtnInsert { get; set; }
    private ICommand? OnClickBtnUpdate { get; set; }
    private ICommand? OnClickBtnDelete { get; set; }
    
    // logic
    
    private ObservableCollection<Position> Positions { get; set; }

    // in parts
    private string Name { get; set; }
    private decimal Salary { get; set; }
    // whole
    private Position _selectedValue;
    private Position SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;

            if (value == null) return;
            Name = value.Name!;
            Salary = value.Salary!;
        }
    }

    public PositionControlViewModel(IPageNavigation container, IScreen? screen)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = DbInstance.GetInstance();
        
        Positions = new ObservableCollection<Position>(Db.Positions!);
        
        OnClickBtnInsert = ReactiveCommand.Create(Insert);
        OnClickBtnUpdate = ReactiveCommand.Create(Update);
        OnClickBtnDelete = ReactiveCommand.Create(Delete);
    }
    
    private void Insert()
    {
        var inserting = new Position()
        {
            Name = Name,
            Salary = Salary
        };
        Positions.Add(inserting);
        Db.Positions!.Add(inserting);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }
    
    private void Update()
    {
        SelectedValue.Name = Name;
        SelectedValue.Salary = Salary;
        Db.Positions!.Update(SelectedValue);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
        
        Positions.Clear();
        Positions = new ObservableCollection<Position>(Db.Positions!);
    }

    private void Delete()
    {
        Db.Positions!.Remove(SelectedValue);
        try
        {
            Db.SaveChanges(); 
            Positions.Remove(SelectedValue);
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }
}