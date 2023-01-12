using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Ufo
{
    public class DeactivateUfoRayWhenTackled : MonoBehaviour
    {
        [SerializeField] private KinematicMover _mover;
        [SerializeField] private UfoRay _ray;

        private void OnEnable() =>
            _mover.Tackled += OnTackled;

        private void OnDisable() =>
            _mover.Tackled -= OnTackled;

        private void OnTackled() =>
            _ray.DeactivateRay();
    }
}