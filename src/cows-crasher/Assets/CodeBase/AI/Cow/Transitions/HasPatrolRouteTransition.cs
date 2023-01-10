using CodeBase.AI.Components;
using CodeBase.AI.Cow.Transitions.Abstract;
using UnityEngine;

namespace CodeBase.AI.Cow.Transitions
{
    public class HasPatrolRouteTransition : Transition
    {
        [SerializeField] private PatrolRoute _patrolRoute;
        [SerializeField] private Timer _pause;
        
        public override bool NeedTransit() =>
            _patrolRoute != null && _patrolRoute.Points.Length > 0 && _pause.IsDone;
    }
}