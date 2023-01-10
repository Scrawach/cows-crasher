using CodeBase.AI.Components;
using CodeBase.AI.Cow.Transitions.Abstract;

namespace CodeBase.AI.Cow.Transitions
{
    public class AttractTransition : Transition
    {
        public UfoAttractedBody AttractedBody;

        public override bool NeedTransit() =>
            AttractedBody.IsAttracting;
    }
}