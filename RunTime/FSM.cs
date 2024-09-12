using UnityEngine;

namespace Fsm_Mk2
{
    public class Fsm
    {
        private State _current;

        public Fsm(State current)
        {
            _current = current;
        }

        public void Update()
        {
            _current.Tick(Time.deltaTime);
        }

        public void FixedUpdate()
        {
            _current.FixedTick(Time.deltaTime);
        }

        public void ApplyTransition(Transition transition)
        {
            if (transition == null) return;
            if (!_current.TryGetTransition(transition)) return;

            transition.From.Exit();
            transition.To.Enter();
            _current = transition.To;
        }

        public State GetCurrentState()
        {
            return _current;
        }
    }
}