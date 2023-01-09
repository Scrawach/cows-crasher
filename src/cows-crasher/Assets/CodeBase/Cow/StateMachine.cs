using System.Linq;
using CodeBase.Cow.States.Abstract;

namespace CodeBase.Cow
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