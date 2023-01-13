using CodeBase.Common;
using UnityEngine;

namespace CodeBase.AI.Components
{
    public class TackleWhenCollide : MonoBehaviour
    {
        [SerializeField] private Observer _observer;
        [SerializeField] private float _strength;
        [SerializeField] private ParticleSystem _deadVfx;

        private void OnEnable() =>
            _observer.Entered += OnCollided;

        private void OnDisable() =>
            _observer.Entered -= OnCollided;

        private void OnCollided(GameObject target)
        {
            var mover = target.GetComponentInParent<KinematicMover>();
            if (mover != null)
            {
                var directionToTarget = mover.transform.position - transform.position;
                mover.Tackle(directionToTarget.normalized, _strength);
            }

            Instantiate(_deadVfx, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}