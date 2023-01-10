using UnityEngine;

namespace CodeBase.AI.Components
{
    public class FindSafetyPlace : MonoBehaviour
    {
        [SerializeField] private SafetyPlace _nearbySafetyPlace;
        [SerializeField] private float _radius = 10f;
        
        public bool HasSafetyPlaceNearby()
        {
            var colliderAround = Physics.OverlapSphere(transform.position, _radius);

            foreach (var col in colliderAround)
            {
                if (col.TryGetComponent(out SafetyPlace safety) && safety.HasFreeSpace())
                {
                    _nearbySafetyPlace = safety;
                    return true;
                }
            }
            
            return false;
        }

        public SafetyPlace Nearby() =>
            _nearbySafetyPlace;
    }
}