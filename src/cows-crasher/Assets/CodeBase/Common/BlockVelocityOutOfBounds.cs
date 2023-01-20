using CodeBase.LevelManagement;
using UnityEngine;

namespace CodeBase.Common
{
    public class BlockVelocityOutOfBounds : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private LevelBounds _bounds;

        private void Update()
        {
            var velocity = _rigidbody.velocity;
            var nextPosition = transform.position + velocity;

            if (_bounds.Has(nextPosition)) 
                return;
            
            velocity = new Vector3(0, velocity.y, 0);
            _rigidbody.velocity = velocity;
        }
    }
}