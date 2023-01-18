using CodeBase.AI.Components;
using CodeBase.AI.Cow.Transitions.Abstract;
using UnityEngine;

namespace CodeBase.AI.Cow.Transitions
{
    public class IsRaisedTransition : Transition
    {
        [SerializeField] private Timer _risingTime;

        public override bool NeedTransit() =>
            _risingTime.IsDone;
    }
}