using CodeBase.Ufo;
using UnityEngine;

namespace CodeBase.Logic
{
    public class ThrowAwayCowWhenTackled : MonoBehaviour
    {
        [SerializeField] private KinematicMover _mover;
        [SerializeField] private UfoCollector _collector;

        private void OnEnable() =>
            _mover.Tackled += OnTackled;

        private void OnDisable() =>
            _mover.Tackled -= OnTackled;

        private void OnTackled() =>
            _collector.Uncollect();
    }
}