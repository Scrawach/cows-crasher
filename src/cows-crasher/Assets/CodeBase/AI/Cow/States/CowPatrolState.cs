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
        [FormerlySerializedAs("_route")] [SerializeField] private PatrolRoute patrolRoute;
        
        [field: SerializeField] public override Transition[] Transitions { get; protected set; }

        private Vector3 _currentGoal;
        private int _goalIndex;
        
        public bool IsReachedPoint { get; private set; }

        public override void Enter()
        {
            _currentGoal = patrolRoute.Points[_goalIndex].position;
            _agent.enabled = true;
            IsReachedPoint = false;
        }

        public override void Exit() =>
            _agent.enabled = false;

        private void Update()
        {
            if (TargetNotReached(_currentGoal))
            {
                _agent.destination = _currentGoal;
            }
            else
            {
                IsReachedPoint = true;
                _currentGoal = NextGoal();
            }
        }

        private Vector3 NextGoal()
        {
            _goalIndex++;

            if (_goalIndex >= patrolRoute.Points.Length)
                _goalIndex = 0;

            return patrolRoute.Points[_goalIndex].position;
        }
        
        private bool TargetNotReached(Vector3 point) =>
            DistanceTo(point) >= _agent.stoppingDistance;

        private float DistanceTo(Vector3 point)
        {
            var distance = point - _agent.transform.position;
            return Vector3.SqrMagnitude(distance);
        }
    }
}