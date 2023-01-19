using System.Collections.Generic;
using System.Linq;
using CodeBase.AI.Components;
using UnityEngine;

namespace CodeBase.Ufo
{
    public class AntigravityZone : MonoBehaviour
    {
        [SerializeField] private float _strength;
        private readonly List<UfoAttractedBody> _attractedBodies = new List<UfoAttractedBody>();

        private bool _isActivated;
        
        private void Update()
        {
            if (!_isActivated)
                return;

            foreach (var attracted in _attractedBodies)
            {
                attracted.BeginAttract();
                attracted.PullTo(transform.position, _strength);
            }
        }

        public void Activate() =>
            _isActivated = true;

        public void Deactivate()
        {
            _isActivated = false;
            foreach (var attracted in _attractedBodies.Where(a => a.IsAttracting)) 
                attracted.EndAttract();
        }

        public void Remove(UfoAttractedBody body) =>
            _attractedBodies.Remove(body);

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out UfoAttractedBody attracted)) 
                _attractedBodies.Add(attracted);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out UfoAttractedBody attracted)
                && _attractedBodies.Contains(attracted))
            {
                attracted.EndAttract();
                _attractedBodies.Remove(attracted);
            }
        }
    }
}