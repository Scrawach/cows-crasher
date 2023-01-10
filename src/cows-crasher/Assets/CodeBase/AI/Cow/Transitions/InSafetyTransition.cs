using CodeBase.AI.Cow.States;
using CodeBase.AI.Cow.Transitions.Abstract;

namespace CodeBase.AI.Cow.Transitions
{
    public class InSafetyTransition : Transition
    {
        public CowRunAwayState RunAwayState;

        public override bool NeedTransit() =>
            RunAwayState.InSafety;
    }
}