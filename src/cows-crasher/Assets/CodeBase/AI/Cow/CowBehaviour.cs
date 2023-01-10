using CodeBase.AI.Cow.States;
using UnityEngine;

namespace CodeBase.AI.Cow
{
    public class CowBehaviour : MonoBehaviour
    {
        public CowIdleState IdleState;

        private StateMachine _stateMachine;

        private void Awake()
        {
            IdleState.Enter();
            _stateMachine = new StateMachine(IdleState);
        }

        private void Update() =>
            _stateMachine.Update();
    }
}