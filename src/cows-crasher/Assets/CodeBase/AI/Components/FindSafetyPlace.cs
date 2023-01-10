using UnityEngine;

namespace CodeBase.AI.Components
{
    public class FindSafetyPlace : MonoBehaviour
    {
        [SerializeField] private SafetyPlace _nearbySafetyPlace;
        
        public bool HasSafetyPlaceNearby(int radius)
        {
            var colliderAround = Physics.OverlapSphere(transform.position, radius);

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