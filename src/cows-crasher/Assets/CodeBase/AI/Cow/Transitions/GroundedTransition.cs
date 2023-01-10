using CodeBase.AI.Components;
using CodeBase.AI.Cow.Transitions.Abstract;

namespace CodeBase.AI.Cow.Transitions
{
    public class GroundedTransition : Transition
    {
        public GroundedChecker Checker;

        public override bool NeedTransit() =>
            Checker.IsGrounded;
    }
}