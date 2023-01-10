using CodeBase.AI.Components;
using CodeBase.AI.Cow.Transitions.Abstract;
using UnityEngine;

namespace CodeBase.AI.Cow.Transitions
{
    public class TimerOut : Transition
    {
        [SerializeField] private Timer _timer;
        
        public override bool NeedTransit() =>
            _timer.IsDone;
    }
}