using System;
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

