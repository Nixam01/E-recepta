using AppModels;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppController
{
    public interface IController : INotifyPropertyChanged
    {
        IModel Model { get; }

        ApplicationState CurrentState { get; }

        ICommand SearchDrugsCommand { get; }
        ICommand SearchDoctorsCommand { get; }
        ICommand SearchPrescriptionsCommand { get; }

        ICommand ShowListCommand { get; }

        ICommand ShowMapCommand { get; }

        Task SearchDrugsAsync();
        Task SearchDoctorsAsync();
        Task SearchPrescriptionsAsync();

        Task ShowListAsync();

        Task ShowMapAsync();
    }
}
