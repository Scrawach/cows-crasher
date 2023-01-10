using CodeBase.AI.Components;
using CodeBase.AI.Cow.States.Abstract;
using CodeBase.AI.Cow.Transitions.Abstract;
using UnityEngine;

namespace CodeBase.AI.Cow.States
{
    public class CowIdleState : State
    {
        [SerializeField] private Timer _idleTimer;
        
        [field: SerializeField] public override Transition[] Transitions { get; protected set; }
        
        public override void Enter() =>
            _idleTimer.Play();

        public override void Exit() =>
            _idleTimer.Erase();
    }
}