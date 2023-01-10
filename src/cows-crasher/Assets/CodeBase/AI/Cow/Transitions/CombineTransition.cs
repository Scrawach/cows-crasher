using System.Linq;
using CodeBase.AI.Cow.Transitions.Abstract;
using UnityEngine;

namespace CodeBase.AI.Cow.Transitions
{
    public class CombineTransition : Transition
    {
        [SerializeField] private Transition[] _transitions;
        
        public override bool NeedTransit() =>
            _transitions.All(transition => transition.NeedTransit());
    }
}