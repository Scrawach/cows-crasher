using System;
using CodeBase.Audio;
using CodeBase.Projectiles.Abstract;
using UnityEngine;

namespace CodeBase.Turrets
{
    public class Cannon : Weapon
    {
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Projectile _projectile;
        [SerializeField] private WeaponAnimator _animator;
        [SerializeField] private AudioPlayer _attackSfx;
        
        public override bool CanAttack() =>
            true;

        public override void Attack(GameObject target) =>
            _animator.PlayAttack(CreateProjectile(to: target));

        private Action CreateProjectile(GameObject to) =>
            () => 
            {           
                var firePoint = _firePoint.position;
                var projectileInstance = Instantiate(_projectile, firePoint, Quaternion.identity);
                projectileInstance.Construct(to.transform.position);
                Instantiate(_attackSfx, firePoint, Quaternion.identity);
            };
    }
}