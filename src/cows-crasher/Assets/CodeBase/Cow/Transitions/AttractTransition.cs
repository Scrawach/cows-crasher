namespace CodeBase.Cow.Transitions
{
    public class AttractTransition : Transition
    {
        public UfoAttractedBody AttractedBody;

        public override bool NeedTransit() =>
            AttractedBody.IsAttracting;
    }
}