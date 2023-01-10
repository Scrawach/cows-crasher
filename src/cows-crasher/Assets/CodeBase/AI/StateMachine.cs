using System.Linq;
using CodeBase.AI.Cow.States.Abstract;
using UnityEngine;

namespace CodeBase.AI
{
    public class StateMachine
    {
        private State _current;

        public StateMachine(State initial) =>
            _current = initial;

        public void Update()
        {
            foreach (var transition in _current.Transitions.Where(trans => trans.NeedTransit()))
            { 
                Enter(transition.NextState);
                break;
            }
        }

        private void Enter(State state)
        {
            _current.Exit();
            _current.gameObject.SetActive(false);
            
            state.gameObject.SetActive(true);
            state.Enter();
            
            _current = state;
        }
    }
}