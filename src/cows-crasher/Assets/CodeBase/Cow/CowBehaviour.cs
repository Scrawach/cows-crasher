using CodeBase.Cow.States;
using UnityEngine;

namespace CodeBase.Cow
{
    public class CowBehaviour : MonoBehaviour
    {
        public CowIdleState IdleState;

        private StateMachine _stateMachine;

        private void Awake() =>
            _stateMachine = new StateMachine(IdleState);

        private void Update() =>
            _stateMachine.Update();
    }
}