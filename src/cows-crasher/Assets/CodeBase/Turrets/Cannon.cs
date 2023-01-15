using CodeBase.AI.Components;
using CodeBase.AI.Cow;
using CodeBase.Audio;
using CodeBase.Projectiles;
using UnityEngine;

namespace CodeBase.Turrets
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private Observer _targetObserver;
        [SerializeField] private Timer _cooldown;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Projectile _projectile;
        [SerializeField] private AudioPlayer _attackSfx;

        private GameObject _target;
        private bool _isAttacking;

        private void Awake() =>
            _cooldown.Play();

        private void OnEnable()
        {
            _targetObserver.Entered += OnTargetFind;
            _targetObserver.Exited += OnTargetLost;
        }

        private void OnDisable()
        {
            _targetObserver.Entered -= OnTargetFind;
            _targetObserver.Exited -= OnTargetLost;

        }

        private void Update()
        {
            if (CanAttack()) 
                Attack(_target);
        }

        private bool CanAttack() =>
            HasTarget() && CooldownIsUp();

        private void Attack(GameObject target)
        {
            var projectileInstance = Instantiate(_projectile, _firePoint.position, Quaternion.identity);
            projectileInstance.Construct(target.transform.position);
            Instantiate(_attackSfx, _firePoint.position, Quaternion.identity);
            _cooldown.Play();
        }
        
        private bool CooldownIsUp() =>
            _cooldown.IsDone;

        private bool HasTarget() =>
            _target != null;

        private void OnTargetFind(GameObject target) =>
            _target = target;

        private void OnTargetLost(GameObject target) =>
            _target = null;
    }
}