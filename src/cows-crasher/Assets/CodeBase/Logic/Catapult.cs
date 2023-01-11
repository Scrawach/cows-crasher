using CodeBase.AI.Components;
using CodeBase.Logic.Projectiles;
using UnityEngine;

namespace CodeBase.Logic
{
    public class Catapult : MonoBehaviour
    {
        [SerializeField] private Observer _targetObserver;
        [SerializeField] private RotateToTarget _rotateToTarget;
        [SerializeField] private Timer _cooldown;
        [SerializeField] private float _attackAngle;
        [SerializeField] private Projectile _projectile;

        private GameObject _target;

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
            if (_target != null && _cooldown.IsDone)
            {
                if (_rotateToTarget.AngleToTarget > _attackAngle)
                    return;
                
                Attack(_target);
                _cooldown.Play();
            }
        }

        private void Attack(GameObject target)
        {
            var projectileInstance = Instantiate(_projectile, transform.position, Quaternion.identity);
            projectileInstance.Construct(target.transform.position);
        }

        private void OnTargetFind(GameObject target) =>
            _target = target;

        private void OnTargetLost(GameObject target) =>
            _target = null;
    }
}