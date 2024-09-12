using System;

namespace Fsm_Mk2
{
    public abstract class FinishableState : State
    {
        public event Action OnFinish;

        public virtual void Finish() => OnFinish?.Invoke();
    }
}