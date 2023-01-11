using System;
using System.Collections.Generic;
using CodeBase.AI.Components;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Ufo
{
    public class UfoCollector : MonoBehaviour
    {
        [SerializeField] private AntigravityZone _antigravity;
        [SerializeField] private UfoRay _ray;

        private List<UfoAttractedBody> _attractedBodies;
        public int Count => _attractedBodies.Count;

        public event Action Changed; 

        private void Awake() =>
            _attractedBodies = new List<UfoAttractedBody>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out UfoAttractedBody attracted)) 
                Collect(attracted);
        }

        private void Collect(UfoAttractedBody attractedBody)
        {
            _ray.DeactivateRay();
            _antigravity.Remove(attractedBody);
            attractedBody.Collect();
            attractedBody.transform.parent = transform;
            _attractedBodies.Add(attractedBody);
            
            Changed?.Invoke();
        }

        public void Uncollect()
        {
            if (Count <= 0)
                return;
            
            Changed?.Invoke();
            var randomIndex = Random.Range(0, _attractedBodies.Count);
            var body = _attractedBodies[randomIndex];
            body.transform.parent = null;
            _attractedBodies.Remove(body);
            body.Uncollect();
        }
    }
}