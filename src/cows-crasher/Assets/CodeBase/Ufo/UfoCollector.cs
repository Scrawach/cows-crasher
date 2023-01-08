using UnityEngine;

namespace CodeBase.Ufo
{
    public class UfoCollector : MonoBehaviour
    {
        [SerializeField] 
        private UfoRay _ray;
        
        public int Count;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out UfoAttractedObject attracted)) 
                Collect(attracted);
        }

        private void Collect(UfoAttractedObject attractedObject)
        {
            Count++;
            _ray.Remove(attractedObject);
            Destroy(attractedObject.gameObject);
        }
    }
}