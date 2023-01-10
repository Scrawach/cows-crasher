using CodeBase.AI.Cow.Transitions.Abstract;
using UnityEngine;

namespace CodeBase.AI.Cow.States.Abstract
{
    public abstract class State : MonoBehaviour
    {
        [field: SerializeField] public Transition[] Transitions { get; private set; }
        public abstract void Enter();
        public abstract void Exit();
    }
}