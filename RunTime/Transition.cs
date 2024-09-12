using System;

namespace Fsm_Mk2
{
    public class Transition
    {
        public State From;
        public State To;

        public event Action TransitionAction;

        public void Do()
        {
            From.Exit();
            TransitionAction?.Invoke();
            To.Enter();
        }
    }
}

