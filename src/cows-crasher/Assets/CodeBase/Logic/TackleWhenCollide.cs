using UnityEngine;

namespace CodeBase.Logic
{
    public class TackleWhenCollide : MonoBehaviour
    {
        [SerializeField] private Observer _observer;
        [SerializeField] private float _strength;

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
            Destroy(gameObject);
        }
    }
}