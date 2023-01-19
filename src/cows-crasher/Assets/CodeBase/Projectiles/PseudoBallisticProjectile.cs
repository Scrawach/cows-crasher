using CodeBase.Common;
using UnityEngine;

namespace CodeBase.Projectiles
{
    public class PseudoBallisticProjectile : Projectile
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _heightOffset;
        [SerializeField] private AnimationCurve _climbCurve;
        [SerializeField] private Timer _climbTimer;
        
        private Vector3 _direction;
        private float _startHeight;
        private float _targetHeight;
        
        public override void Construct(Vector3 target)
        {
            _startHeight = transform.position.y;
            _targetHeight = target.y + _heightOffset;
            _direction = DirectionWithoutHeightTo(target);
            _climbTimer.Play();
        }

        private void Update()
        {
            var step = Time.deltaTime * _speed;
            var desiredPosition = transform.position + _direction * step;
            
            if (_climbTimer.IsPlaying)
            {
                desiredPosition.y = CalculateHeight(_startHeight, _targetHeight, _climbTimer.Progress);
                transform.rotation = Quaternion.LookRotation((desiredPosition - transform.position).normalized);
            }

            transform.position = desiredPosition;
        }

        private float CalculateHeight(float start, float target, float time) =>
            Mathf.Lerp(start, target, _climbCurve.Evaluate(time));

        private Vector3 DirectionWithoutHeightTo(Vector3 target)
        {
            var position = transform.position;
            var direction = target - position;
            direction.y = 0;
            return direction.normalized;
        }
    }
}