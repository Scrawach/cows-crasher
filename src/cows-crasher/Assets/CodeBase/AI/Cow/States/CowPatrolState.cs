using CodeBase.AI.Components;
using CodeBase.AI.Cow.States.Abstract;
using CodeBase.AI.Cow.Transitions.Abstract;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace CodeBase.AI.Cow.States
{
    public class CowPatrolState : State
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private AgentMoveToPoint _moveToPoint;
        [SerializeField] private PatrolRoute patrolRoute;
        
        private Vector3 _currentGoal;
        private int _goalIndex = -1;

        public bool IsReachedPoint => !_moveToPoint.TargetNotReached();

        public override void Enter()
        {
            _agent.enabled = true;
            _moveToPoint.MoveTo(NextGoal());
        }

        public override void Exit()
        {
            _moveToPoint.ResetMovement();
            _agent.enabled = false;
        }

        private Vector3 NextGoal()
        {
            _goalIndex++;

            if (_goalIndex >= patrolRoute.Points.Length)
                _goalIndex = 0;

            return patrolRoute.Points[_goalIndex].position;
        }
    }
}