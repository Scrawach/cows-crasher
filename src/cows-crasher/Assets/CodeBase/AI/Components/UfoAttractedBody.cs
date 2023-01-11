using UnityEngine;

namespace CodeBase.AI.Components
{
    public class UfoAttractedBody : MonoBehaviour
    {
        [SerializeField] 
        private Rigidbody _body;

        [field:SerializeField]
        public bool IsAttracting { get; private set; }
        
        public void PullTo(Vector3 point, float withSpeed)
        {
            var direction = point - transform.position;
            direction.Normalize();
            var movement = direction * withSpeed;
            _body.velocity = movement;
            _body.angularVelocity = movement;
        }
        
        public void BeginAttract() =>
            IsAttracting = true;

        public void EndAttract() =>
            IsAttracting = false;

        public void Collect() =>
            Destroy(gameObject);
    }
}