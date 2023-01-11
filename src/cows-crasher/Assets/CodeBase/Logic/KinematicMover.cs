using System;
using CodeBase.AI.Components;
using UnityEngine;

namespace CodeBase.Logic
{
    public class KinematicMover : Mover
    {
        [SerializeField] private Timer _tackleProcess;
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
            
            transform.Translate(Direction * moveStep, Space.World);
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
            _tackleMovement = direction * strength;
            _tackleMovement.y = 0;
            _hasTackle = true;
            _tackleProcess.Play();
            Tackled?.Invoke();
        }
    }
}