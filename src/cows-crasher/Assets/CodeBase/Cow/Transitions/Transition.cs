using CodeBase.Cow.States.Abstract;
using UnityEngine;

namespace CodeBase.Cow.Transitions
{
    public abstract class Transition : MonoBehaviour
    {
        public State NextState;
        public abstract bool NeedTransit();
    }
}