using CodeBase.AI.Cow.Transitions.Abstract;
using UnityEngine;

namespace CodeBase.AI.Cow.States.Abstract
{
    public abstract class State : MonoBehaviour
    {
        public abstract Transition[] Transitions { get; protected set; }
        public abstract void Enter();
        public abstract void Exit();
    }
}