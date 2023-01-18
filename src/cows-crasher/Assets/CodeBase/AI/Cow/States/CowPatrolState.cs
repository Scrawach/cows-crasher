using CodeBase.AI.Components;
using CodeBase.AI.Cow.States.Abstract;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.AI.Cow.States
{
    public class CowPatrolState : State
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private AgentMoveToPoint _moveToPoint;
        [SerializeField] private PatrolRoute _patrolRoute;
        
        private Vector3 _currentGoal;

        public bool IsReachedPoint => !_moveToPoint.TargetNotReached();

        public override void Enter()
        {
            _agent.enabled = true;
            _moveToPoint.MoveTo(_patrolRoute.NextGoal());
        }

        public override void Exit()
        {
            _moveToPoint.ResetMovement();
            _agent.enabled = false;
        }
    }
}