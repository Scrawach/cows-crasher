using CodeBase.AI.Components;
using UnityEngine;

namespace CodeBase.Ufo
{
    public class UfoCollector : MonoBehaviour
    {
        [SerializeField] private AntigravityZone _antigravity;
        [SerializeField] private UfoRay _ray;
        
        public int Count;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out UfoAttractedBody attracted)) 
                Collect(attracted);
        }

        private void Collect(UfoAttractedBody attractedBody)
        {
            Count++;
            _antigravity.Remove(attractedBody);
            _ray.DeactivateRay();
            attractedBody.Collect();
        }
    }
}