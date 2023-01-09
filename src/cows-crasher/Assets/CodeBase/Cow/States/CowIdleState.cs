using CodeBase.Cow.States.Abstract;
using CodeBase.Cow.Transitions;
using UnityEngine;

namespace CodeBase.Cow.States
{
    public class CowIdleState : State
    {
        [field: SerializeField] public override Transition[] Transitions { get; protected set; }
        public override void Enter() { }
        public override void Exit() { }
    }
}