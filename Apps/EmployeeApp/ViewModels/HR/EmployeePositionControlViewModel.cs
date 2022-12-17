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

public class EmployeePositionControlViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "employeePositionControl";
    public IScreen? HostScreen { get; }
    private Db Db { get; set; }

    // ui

    private ICommand? OnClickBtnInsert { get; set; }
    private ICommand? OnClickBtnDelete { get; set; }
    
    // logic
    
    private ObservableCollection<EmployeePosition> EmployeePositions { get; set; }
    private List<Position> Positions { get; set; }
    
    // in parts
    private Position Position { get; set; }
    // whole
    private EmployeePosition _selectedValue;
    private EmployeePosition SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;

            if (value == null) return;
            Position = value.Position!;
        }
    }

    public EmployeePositionControlViewModel(Employee currentEmployee, IPageNavigation container, IScreen? screen)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = DbInstance.GetInstance();
        
        EmployeePositions = new ObservableCollection<EmployeePosition>(Db.EmployeePositions!.Where(x 
            => x.EmployeeId.Equals(currentEmployee.Id)));
        Positions = new List<Position>(Db.Positions!);
        
        OnClickBtnInsert = ReactiveCommand.Create(() => Insert(currentEmployee));
        OnClickBtnDelete = ReactiveCommand.Create(Delete);
    }
    
    private void Insert(Employee currentEmployee)
    {
        var inserting = new EmployeePosition()
        {
            Employee = currentEmployee,
            Position = Position
        };
        EmployeePositions.Add(inserting);
        Db.EmployeePositions!.Add(inserting);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }

    private void Delete()
    {
        Db.EmployeePositions!.Remove(SelectedValue);
        try
        {
            Db.SaveChanges(); 
            EmployeePositions.Remove(SelectedValue);
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }
}