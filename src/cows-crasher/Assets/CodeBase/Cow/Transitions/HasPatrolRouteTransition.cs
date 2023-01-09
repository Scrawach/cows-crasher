using CodeBase.Cow.States;
using UnityEngine;

namespace CodeBase.Cow.Transitions
{
    public class HasPatrolRouteTransition : Transition
    {
        [SerializeField] private PatrolRoute _patrolRoute;
        [SerializeField] private CowIdleState _idleState;
        
        public override bool NeedTransit() =>
            _patrolRoute != null && _patrolRoute.Points.Length > 0 && _idleState.PauseElapsed;
    }
}