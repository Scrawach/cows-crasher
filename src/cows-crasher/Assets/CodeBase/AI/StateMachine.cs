using System.Linq;
using CodeBase.AI.Cow.States.Abstract;

namespace CodeBase.AI
{
    public class StateMachine
    {
        private State _current;
        
        public void Update()
        {
            var transition = _current.Transitions.FirstOrDefault(trans => trans.NeedTransit());
            
            if (transition != null) 
                Enter(transition.NextState);
        }

        public void Enter(State state) =>
            _current = SwitchTo(state);

        private State SwitchTo(State state)
        {
            if (_current) ExitFrom(_current);
            
            EnterTo(state);
            return state;
        }

        private static void ExitFrom(State state)
        {
            state.Exit();
            state.gameObject.SetActive(false);
        }

        private static void EnterTo(State state)
        {
            state.Enter();
            state.gameObject.SetActive(true);
        }
    }
}