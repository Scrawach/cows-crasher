using CodeBase.Projectiles.Abstract;
using UnityEngine;

namespace CodeBase.Projectiles
{
    public class LinearProjectile : Projectile
    {
        [SerializeField] private float _speed;

        private Vector3 _direction;

        public override void Construct(Vector3 target)
        {
            _direction = target - transform.position;
            transform.rotation = Quaternion.LookRotation(_direction);
        }

        private void Update()
        {
            var step = Time.deltaTime * _speed;
            transform.Translate(_direction * step, Space.World);
        }
    }
}