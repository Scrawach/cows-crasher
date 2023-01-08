using UnityEngine;

namespace CodeBase.Ufo
{
    public class UfoAttractedObject : MonoBehaviour
    {
        [SerializeField] 
        private Rigidbody _body;
        
        public bool IsAttracting { get; private set; }
        
        public void PullTo(Vector3 point, float withSpeed)
        {
            var direction = point - transform.position;
            direction.Normalize();
            var movement = direction * withSpeed;
            _body.velocity = movement;
            _body.angularVelocity = movement;
        }

        public void BeginAttract()
        {
            IsAttracting = true;
            _body.useGravity = false;
            _body.velocity = Vector3.zero;
        }

        public void EndAttract()
        {
            IsAttracting = false;
            _body.useGravity = true;
        }
    }
}