using CodeBase.AI.Cow.States.Abstract;
using UnityEngine;

namespace CodeBase.AI.Cow
{
    public class CowBehaviour : MonoBehaviour
    {
        [SerializeField] public State _initialState;

        private StateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = new StateMachine();
            _stateMachine.Enter(_initialState);
        }

        private void Update() =>
            _stateMachine.Update();
    }
}