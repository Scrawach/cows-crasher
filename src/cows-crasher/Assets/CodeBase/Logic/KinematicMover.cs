using UnityEngine;

namespace CodeBase.Logic
{
    public class KinematicMover : Mover
    {
        private Vector3 _tackleMovement;
        [SerializeField] private float _tackleDuration = 0.2f;
        
        private float _tackleElapsed;
        private bool _hasTackle;
        
        public Vector3 Direction { get; private set; }

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
            _tackleElapsed += Time.deltaTime;
            
            if (_tackleElapsed >= _tackleDuration)
            {
                _hasTackle = false;
                _tackleElapsed = 0;
            }
        }

        public void Tackle(Vector3 direction, float strength)
        {
            _tackleMovement = direction * strength;
            _tackleMovement.y = 0;
            _hasTackle = true;
        }
    }
}