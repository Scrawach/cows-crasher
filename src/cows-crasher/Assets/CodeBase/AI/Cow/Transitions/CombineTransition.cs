using System.Linq;
using CodeBase.AI.Cow.Transitions.Abstract;
using UnityEngine;

namespace CodeBase.AI.Cow.Transitions
{
    public class CombineTransition : Transition
    {
        [SerializeField] private Transition[] _transitions;
        [SerializeField] private bool _result;
        
        public override bool NeedTransit()
        {
            _result= true;

            foreach (var transition in _transitions)
            {
                _result &= transition.NeedTransit();
            }
            
            return _result;
        }
    }
}