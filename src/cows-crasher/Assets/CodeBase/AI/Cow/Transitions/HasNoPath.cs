using CodeBase.AI.Cow.Transitions.Abstract;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.AI.Cow.Transitions
{
    public class HasNoPath : Transition
    {
        [SerializeField] private NavMeshAgent _agent;
        
        public override bool NeedTransit() =>
            !_agent.hasPath;
    }
}