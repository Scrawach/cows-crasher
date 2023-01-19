using CodeBase.AI.Cow.Transitions.Abstract;
using CodeBase.Common;
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