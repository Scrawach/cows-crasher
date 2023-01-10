using CodeBase.AI.Cow.States;
using CodeBase.AI.Cow.Transitions.Abstract;
using UnityEngine;

namespace CodeBase.AI.Cow.Transitions
{
    public class IsReachedPatrolGoalTransition : Transition
    {
        [SerializeField] private CowPatrolState _patrolState;
        
        public override bool NeedTransit() =>
            _patrolState.IsReachedPoint;
    }
}