using System.Runtime.Serialization;
using ReactiveUI;
using UserApp.Models;

namespace UserApp.ViewModels
{
    public class MainWindowViewModel : ReactiveObject, IScreen, IPageNavigation
    {
        [DataMember] public RoutingState Router { get; set; } = new();

        public void OpnAuthorizationPage()
        {
            throw new System.NotImplementedException();
        }

        public void OpnEmployeeControlPage()
        {
            throw new System.NotImplementedException();
        }

        public void OpnEmployeePositionControlPage()
        {
            throw new System.NotImplementedException();
        }

        public void OpnEmployerControlPage()
        {
            throw new System.NotImplementedException();
        }

        public void OpnProfessionControlPage()
        {
            throw new System.NotImplementedException();
        }

        public void OpnVacancyControlPage()
        {
            throw new System.NotImplementedException();
        }

        public void OpnEmployedControlPage()
        {
            throw new System.NotImplementedException();
        }

        public void OpnEducationForProfessionControlPage()
        {
            throw new System.NotImplementedException();
        }

        public void OpnEmployedEducationControlPage()
        {
            throw new System.NotImplementedException();
        }

        public void OpnJobApplicationControlPage()
        {
            throw new System.NotImplementedException();
        }
    }
}