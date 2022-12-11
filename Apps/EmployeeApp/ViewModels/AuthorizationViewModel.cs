using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Input;
using Entities;
using Entities.Models;
using ReactiveUI;
using Splat;

namespace EmployeeApp.ViewModels;

[DataContract]
public class AuthorizationViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "authorization";
    public IScreen HostScreen { get; }
    private Db Db { get; set; }
    
    private string? Login { get; set; } 
    private string? Password { get; set; } 
    
    private ICommand OnClickBtnLogin { get; set; }

    public AuthorizationViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = DbInstance.GetInstance();
        
        OnClickBtnLogin = ReactiveCommand.Create(() => AttemptedAuthorization(container));
    }
    
    private void AttemptedAuthorization(IPageNavigation container)
    {
        var user = new Employee();
        if (Db.Employees != null) user = Db.Employees.FirstOrDefault(x => x.Login!.Equals(Login));
        if (user == null) return;
        if (user.Password!.Equals(Password))
        {
            container.OpnMainMenuPage(user);
        }
        else
        {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Ошибка входа", "Неверный пароль.");
            messageBox.Show();
        }
    }
}