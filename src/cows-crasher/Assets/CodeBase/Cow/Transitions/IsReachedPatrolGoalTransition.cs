using CodeBase.Cow.States;
using UnityEngine;

namespace CodeBase.Cow.Transitions
{
    public class IsReachedPatrolGoalTransition : Transition
    {
        [SerializeField] private CowPatrolState _patrolState;
        
        public override bool NeedTransit() =>
            _patrolState.IsReachedPoint;
    }
}