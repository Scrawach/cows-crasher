using CodeBase.Cow.States;

namespace CodeBase.Cow.Transitions
{
    public class InSafetyTransition : Transition
    {
        public CowRunAwayState RunAwayState;

        public override bool NeedTransit() =>
            RunAwayState.InSafety;
    }
}