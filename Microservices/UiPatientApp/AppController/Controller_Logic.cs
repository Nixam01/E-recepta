using System.Threading.Tasks;

using System.Windows.Input;

namespace AppController
{
    public partial class Controller : IController
    {
        public ApplicationState CurrentState
        {
            get { return this.currentState; }
            set
            {
                this.currentState = value;

                this.RaisePropertyChanged("CurrentState");
            }
        }
        private ApplicationState currentState = ApplicationState.List;

        public ICommand SearchDrugsCommand { get; private set; }
        public ICommand SearchDoctorsCommand { get; private set; }
        public ICommand SearchPrescriptionsCommand { get; private set; }

        public ICommand ShowListCommand { get; private set; }

        public ICommand ShowMapCommand { get; private set; }

        public async Task SearchDrugsAsync()
        {
            await Task.Run(() => this.SearchDrugs());
        }

        public async Task SearchDoctorsAsync()
        {
            await Task.Run(() => this.SearchDoctors());
        }

        public async Task SearchPrescriptionsAsync()
        {
            await Task.Run(() => this.SearchPrescriptions());
        }

        public async Task ShowListAsync()
        {
            await Task.Run(() => this.ShowList());
        }

        public async Task ShowMapAsync()
        {
            await Task.Run(() => this.ShowMap());
        }

        private void SearchDrugs()
        {
            this.Model.LoadDrugList();
        }

        private void SearchDoctors()
        {
            this.Model.LoadDoctorList();
        }

        private void SearchPrescriptions()
        {
            this.Model.LoadPrescriptionList();
        }

        private void ShowList()
        {
            switch (this.CurrentState)
            {
                case ApplicationState.List:
                    break;

                default:
                    this.CurrentState = ApplicationState.List;
                    break;
            }
        }

        private void ShowMap()
        {
            switch (this.CurrentState)
            {
                case ApplicationState.Map:
                    break;

                default:
                    this.CurrentState = ApplicationState.Map;
                    break;
            }
        }
    }
}
