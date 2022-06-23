using System;

namespace Utilities
{
    public class EmptyEventDispatcher : IEventDispatcher
    {
        #region IEventDispatcher

        public void Dispatch(Action eventAction)
        {
        }
        #endregion
    }
}
