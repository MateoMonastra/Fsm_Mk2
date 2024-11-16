using UnityEngine;
using System;

namespace Fsm_Mk2
{
    public class Fsm
    {
        private State _current;

        public Fsm(State current)
        {
            _current = current;
            _current.Enter();
        }

        public void Update()
        {
            _current.Tick(Time.deltaTime);
        }

        public void FixedUpdate()
        {
            _current.FixedTick(Time.deltaTime);
        }

        public bool TryTransitionTo(string id)
        {
            if (_current.TryGetTransition(id, out var transition))
            {
                transition.Do();
                _current = transition.To;
                return true;
            }

            return false;
        }

        [Obsolete("warning use Fsm.TryTransitionTo instead.")]
        public void ApplyTransition(Transition transition)
        {
            if (transition == null) return;
            if (!_current.TryGetTransition(transition)) return;

            transition.Do();
            _current = transition.To;
        }

        public State GetCurrentState()
        {
            return _current;
        }
    }
}