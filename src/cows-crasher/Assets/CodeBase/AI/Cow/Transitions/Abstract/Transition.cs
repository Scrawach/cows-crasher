using CodeBase.AI.Cow.States.Abstract;
using UnityEngine;

namespace CodeBase.AI.Cow.Transitions.Abstract
{
    public abstract class Transition : MonoBehaviour
    {
        public State NextState;
        public abstract bool NeedTransit();
    }
}