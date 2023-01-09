namespace CodeBase.Cow.Transitions
{
    public class GroundedTransition : Transition
    {
        public GroundedChecker Checker;

        public override bool NeedTransit() =>
            Checker.IsGrounded;
    }
}