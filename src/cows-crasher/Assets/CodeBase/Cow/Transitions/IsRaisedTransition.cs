using CodeBase.Cow.States;
using CodeBase.Cow.States.Abstract;

namespace CodeBase.Cow.Transitions
{
    public class IsRaisedTransition : Transition
    {
        public CowRaisingState RisingState;
        
        public override bool NeedTransit() =>
            RisingState.IsRaised;
    }
}