using CodeBase.Cow.StateMachine.States.Abstract;

namespace CodeBase.Cow.StateMachine.States
{
    public class CowIdleState : IState, IUpdatableState
    {
        private readonly CowStateMachine _stateMachine;
        private readonly CowBehaviour _cowBehaviour;

        public CowIdleState(CowStateMachine stateMachine, CowBehaviour cowBehaviour)
        {
            _stateMachine = stateMachine;
            _cowBehaviour = cowBehaviour;
        }
        
        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }

        public void Update(float delta)
        {
            if (_cowBehaviour.attractedBody.IsAttracting)
                _stateMachine.Enter<CowLevitationState>();
        }
    }
}