using CodeBase.Common;
using UnityEngine;

namespace CodeBase.Projectiles
{
    public class PseudoBallisticProjectile : Projectile
    {
        [SerializeField] private float _speed;
        [SerializeField] private AnimationCurve _height;
        [SerializeField] private float _heightOffset;
        [SerializeField] private Timer _climbTimer;
        
        private Vector3 _direction;
        private Vector3 _target;
        private float _startHeight;
        
        public override void Construct(Vector3 target)
        {
            _target = target;
            _direction = target - transform.position;
            _direction.y = 0;
            _direction.Normalize();
            _startHeight = transform.position.y;
            _climbTimer.Play();
        }

        private void Update()
        {
            var timeStep = Time.deltaTime * _speed;
            var desiredPosition = transform.position + _direction * timeStep;
            
            if (_climbTimer.IsPlaying)
            {
                desiredPosition.y = CalculateHeight(_climbTimer.Progress);
                transform.rotation = Quaternion.LookRotation((desiredPosition - transform.position).normalized);
            }
            else
            {
                desiredPosition.y = _target.y + _heightOffset;
            }

            transform.position = desiredPosition;
        }

        private float CalculateHeight(float time) =>
            Mathf.Lerp(_startHeight, _target.y + _heightOffset, _height.Evaluate(time));
    }
}