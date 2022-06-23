using AppModels;
using Utilities;

namespace AppController
{
    public partial class Controller : PropertyContainerBase, IController
    {
        public IModel Model { get; private set; }

        public Controller(IEventDispatcher dispatcher, IModel model) : base(dispatcher)
        {
            this.Model = model;

            this.SearchDrugsCommand = new ControllerCommand(this.SearchDrugs);

            this.SearchDoctorsCommand = new ControllerCommand(this.SearchDoctors);

            this.SearchPatientsCommand = new ControllerCommand(this.SearchPatients);

            this.SearchPrescriptionsCommand = new ControllerCommand(this.SearchPrescriptions);

            this.ShowListCommand = new ControllerCommand(this.ShowList);

            this.ShowMapCommand = new ControllerCommand(this.ShowMap);
        }
    }
}
