using UnityEngine;

namespace CodeBase.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _rotationAngle;
        [SerializeField] private float _distance;
        [SerializeField] private float _smoothSpeed;

        private void LateUpdate()
        {
            if (HasTarget()) 
                Follow(_target, with: _rotationAngle);
        }

        public void Follow(Transform target) =>
            _target = target;

        private bool HasTarget() =>
            _target != null;

        private void Follow(Transform target, Vector3 with)
        {
            var desiredRotation = Quaternion.Euler(with);
            var desiredPosition = DistanceWithRotate(desiredRotation) + target.position;
            var selfTransform = transform;
            
            selfTransform.rotation = desiredRotation;
            selfTransform.position += SmoothPositionStep(desiredPosition, _smoothSpeed);
        }
        
        private Vector3 DistanceWithRotate(Quaternion desiredRotation) =>
            desiredRotation * new Vector3(0, 0, -_distance);

        private Vector3 SmoothPositionStep(Vector3 desiredPosition, float speed)
        {
            var step = Time.deltaTime * speed;
            var difference = desiredPosition - transform.position;
            return difference * step;
        }
    }
}
