using CodeBase.Cow.StateMachine.States.Abstract;

namespace CodeBase.Cow.StateMachine.States
{
    public class CowNavigationState : IState, IUpdatableState
    {
        private readonly CowStateMachine _stateMachine;
        private readonly CowBehaviour _cowBehaviour;

        public CowNavigationState(CowStateMachine stateMachine, CowBehaviour cowBehaviour)
        {
            _stateMachine = stateMachine;
            _cowBehaviour = cowBehaviour;
        }

        public void Enter() =>
            _cowBehaviour.Agent.enabled = true;

        public void Exit() =>
            _cowBehaviour.Agent.enabled = false;

        public void Update(float delta)
        {
            if (_cowBehaviour.AttractedObject.IsAttracting)
                _stateMachine.Enter<CowLevitationState>();
        }
    }
}