using System;

namespace Utilities
{
    public interface IEventDispatcher
    {
        void Dispatch(Action action);
    }
}