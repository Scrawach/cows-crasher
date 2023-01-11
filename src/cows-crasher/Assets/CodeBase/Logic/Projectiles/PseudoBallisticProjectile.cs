using UnityEngine;

namespace CodeBase.Logic.Projectiles
{
    public class PseudoBallisticProjectile : Projectile
    {
        [SerializeField] private float _speed;
        [SerializeField] private AnimationCurve _height;
        [SerializeField] private float _heightChangeTime;
        [SerializeField] private float _heightOffset;
        
        private Vector3 _direction;
        private Vector3 _target;
        private float _startHeight;
        private float _elapsed;
        
        public override void Construct(Vector3 target)
        {
            _target = target;
            _direction = (target - transform.position).normalized;
            _startHeight = transform.position.y;
        }

        private void Update()
        {
            var timeStep = Time.deltaTime * _speed;
            var desiredPosition = transform.position + _direction * timeStep;
            
            _elapsed += Time.deltaTime / _heightChangeTime;
            if (_elapsed < 1f)
            {
                desiredPosition.y = CalculateHeight(_elapsed);
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