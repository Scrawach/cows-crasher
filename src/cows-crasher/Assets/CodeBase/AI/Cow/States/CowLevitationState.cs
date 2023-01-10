using CodeBase.AI.Cow.States.Abstract;
using CodeBase.AI.Cow.Transitions.Abstract;
using UnityEngine;

namespace CodeBase.AI.Cow.States
{
    public class CowLevitationState : State
    {
        [SerializeField] private Rigidbody _rigidbody;
        [field: SerializeField] public override Transition[] Transitions { get; protected set; }

        public override void Enter() =>
            _rigidbody.isKinematic = false;
        
        public override void Exit() =>
            _rigidbody.isKinematic = true;
    }
}