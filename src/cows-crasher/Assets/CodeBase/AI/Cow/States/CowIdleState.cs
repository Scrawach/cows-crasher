using CodeBase.AI.Components;
using CodeBase.AI.Cow.States.Abstract;
using CodeBase.AI.Cow.Transitions.Abstract;
using CodeBase.Common;
using UnityEngine;

namespace CodeBase.AI.Cow.States
{
    public class CowIdleState : State
    {
        [SerializeField] private Timer _idleTimer;
        
        public override void Enter() =>
            _idleTimer.Play();

        public override void Exit() =>
            _idleTimer.Erase();
    }
}