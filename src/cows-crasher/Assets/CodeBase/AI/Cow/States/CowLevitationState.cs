using CodeBase.AI.Cow.States.Abstract;
using UnityEngine;

namespace CodeBase.AI.Cow.States
{
    public class CowLevitationState : State
    {
        [SerializeField] private Rigidbody _rigidbody;

        public override void Enter() =>
            _rigidbody.isKinematic = false;
        
        public override void Exit() =>
            _rigidbody.isKinematic = true;
    }
}