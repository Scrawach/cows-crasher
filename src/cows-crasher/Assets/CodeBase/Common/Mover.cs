using UnityEngine;

namespace CodeBase.Common
{
    public abstract class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        
        public Vector3 Movement { get; private set; }
        
        public float Speed => _speed;

        public void Move(Vector3 direction) =>
            Movement = direction;
    }
}