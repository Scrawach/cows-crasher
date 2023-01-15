using System;
using CodeBase.AI.Components;
using CodeBase.LevelManagement;
using UnityEngine;

namespace CodeBase.Common
{
    public class KinematicMover : Mover
    {
        [SerializeField] private Timer _tackleProcess;
        [SerializeField] private LevelBounds _bounds;
        private Vector3 _tackleMovement;
        private bool _hasTackle;
        
        public Vector3 Direction { get; private set; }

        public event Action Tackled; 

        private void Update()
        {
            var moveStep = Speed * Time.deltaTime;
            Direction = Movement;
            
            if (_hasTackle) 
                ProcessTackle();

            var movement = Direction * moveStep;
            var nextPosition = transform.position + movement;

            if (!_bounds.Has(nextPosition))
                return;
            
            transform.Translate(movement, Space.World);
            Direction = Direction.normalized;
        }

        private void ProcessTackle()
        {
            Direction += _tackleMovement;
            if (_tackleProcess.IsDone) 
                _hasTackle = false;
        }

        public void Tackle(Vector3 direction, float strength)
        {
            var tackleMoving = direction * strength;

            if (_hasTackle)
                _tackleMovement += tackleMoving;
            else
                _tackleMovement = tackleMoving;
            
            _tackleMovement.y = 0;
            _hasTackle = true;
            _tackleProcess.Play();
            Tackled?.Invoke();
        }
    }
}