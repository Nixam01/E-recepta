
using Utilities;

namespace AppModels
{
    public partial class Model : PropertyContainerBase, IModel
    {
        public Model(IEventDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}
