using System;

namespace Fsm_Mk2
{
    public class Transition
    {
        public State From { get; set; }
        public State To {  get; set; }
        public string id {  get; set; }

        public event Action OnTransition;

        public void Do()
        {
            From.Exit();
            OnTransition?.Invoke();
            To.Enter();
        }
    }
}

