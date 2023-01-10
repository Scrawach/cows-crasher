using CodeBase.AI.Cow.States;
using CodeBase.AI.Cow.Transitions.Abstract;

namespace CodeBase.AI.Cow.Transitions
{
    public class IsRaisedTransition : Transition
    {
        public CowRaisingState RisingState;
        
        public override bool NeedTransit() =>
            RisingState.IsRaised;
    }
}