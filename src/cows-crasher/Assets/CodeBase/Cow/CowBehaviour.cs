using System;
using CodeBase.Cow.StateMachine;
using CodeBase.Cow.StateMachine.States;
using CodeBase.Logic;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Cow
{
    public class CowBehaviour : MonoBehaviour
    {
        public Rigidbody Rigidbody;
        public NavMeshAgent Agent;
        public AgentMoveToPoint MoveToPoint;
        public NavMeshObstacle Obstacle;
        public UfoAttractedBody attractedBody;
        public LayerMask GroundLayer;
        public Transform Enemy;

        private CowStateMachine _stateMachine;

        public bool IsGrounded { get; private set; }

        private void Awake()
        {
            _stateMachine = new CowStateMachine(this);
            _stateMachine.Enter<CowNavigationState>();
        }

        private void Update() =>
            _stateMachine.Update(Time.deltaTime);
        
        private void OnCollisionEnter(Collision other)
        {
            if ((1 << other.gameObject.layer & GroundLayer) > 0)
                IsGrounded = true;
        }

        private void OnCollisionExit(Collision other)
        {
            if ((1 << other.gameObject.layer & GroundLayer) > 0)
                IsGrounded = false;
        }
    }
}