using CodeBase.Cow.StateMachine.States.Abstract;

namespace CodeBase.Cow.StateMachine.States
{
    public class CowRunAwayState : IState, IUpdatableState
    {
        private readonly CowStateMachine _stateMachine;
        private readonly CowBehaviour _cowBehaviour;

        private const float SafetyDistance = 10f;

        public CowRunAwayState(CowStateMachine stateMachine, CowBehaviour cowBehaviour)
        {
            _stateMachine = stateMachine;
            _cowBehaviour = cowBehaviour;
        }
        
        public void Enter()
        {
            _cowBehaviour.MoveToPoint.enabled = false;
            _cowBehaviour.Agent.enabled = true;
        }

        public void Exit()
        {
            _cowBehaviour.MoveToPoint.enabled = true;
            _cowBehaviour.Agent.enabled = false;
        }

        public void Update(float delta)
        {
            var selfPosition = _cowBehaviour.transform.position;
            var distanceToEnemy = (_cowBehaviour.Enemy.position - selfPosition);
            distanceToEnemy.y = 0;
            
            var runAway = -distanceToEnemy.normalized;
            var nextPoint = runAway * 5f + selfPosition;
            _cowBehaviour.Agent.destination = nextPoint;
            
            if (distanceToEnemy.magnitude > SafetyDistance)
                _stateMachine.Enter<CowIdleState>();
            
            if (_cowBehaviour.attractedBody.IsAttracting)
                _stateMachine.Enter<CowLevitationState>();
        }
    }
}