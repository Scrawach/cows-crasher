using CodeBase.Cow.States.Abstract;
using CodeBase.Cow.Transitions;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Cow.States
{
    public class CowNavigationState : State
    {
        [SerializeField] private NavMeshAgent _agent;
        [field: SerializeField] public override Transition[] Transitions { get; protected set; }

        public override void Enter() =>
            _agent.enabled = true;

        public override void Exit() =>
            _agent.enabled = false;
    }
}