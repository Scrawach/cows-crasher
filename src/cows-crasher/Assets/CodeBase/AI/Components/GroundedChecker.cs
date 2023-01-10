using UnityEngine;

namespace CodeBase.AI.Components
{
    public class GroundedChecker : MonoBehaviour
    {
        public LayerMask GroundLayer;
        
        public bool IsGrounded { get; private set; }
        
        private void OnCollisionEnter(Collision other)
        {
            if ((1 << other.gameObject.layer & GroundLayer) > 0)
                IsGrounded = true;
        }

        private void OnCollisionExit(Collision other)
        {
            if ((1 << other.gameObject.layer & GroundLayer) > 0)
                IsGrounded = false;
        }
    }
}