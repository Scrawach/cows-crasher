using CodeBase.Cow.Transitions;
using UnityEngine;

namespace CodeBase.Cow.States.Abstract
{
    public abstract class State : MonoBehaviour
    {
        public abstract Transition[] Transitions { get; protected set; }
        public abstract void Enter();
        public abstract void Exit();
    }
}