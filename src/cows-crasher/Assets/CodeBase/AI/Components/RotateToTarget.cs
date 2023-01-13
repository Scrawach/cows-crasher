using UnityEngine;

namespace CodeBase.AI.Components
{
    public class RotateToTarget : MonoBehaviour
    {
        [SerializeField] private Observer _targetObserver;
        [SerializeField] private float _rotationSpeed;

        private Transform _target;

        public float AngleToTarget => Quaternion.Angle(transform.rotation, TargetRotation(PositionToLookAt()));
        
        private void OnEnable()
        {
            _targetObserver.Entered += OnTargetEntered;
            _targetObserver.Exited += OnTargetExited;
        }

        private void OnDisable()
        {
            _targetObserver.Entered -= OnTargetEntered;
            _targetObserver.Exited -= OnTargetExited;
        }

        private void Update()
        {
            if (_target != null) 
                transform.rotation = SmoothedRotation(transform.rotation, PositionToLookAt());
        }
        
        private Vector3 PositionToLookAt()
        {
            var positionDelta = (_target.position - transform.position).normalized;
            return new Vector3(positionDelta.x, transform.position.y, positionDelta.z);
        }
    
        private Quaternion SmoothedRotation(Quaternion rotation, Vector3 positionToLook) =>
            Quaternion.RotateTowards(rotation, TargetRotation(positionToLook), _rotationSpeed);

        private Quaternion TargetRotation(Vector3 position) =>
            Quaternion.LookRotation(position);
        
        private void OnTargetEntered(GameObject target) =>
            _target = target.transform;

        private void OnTargetExited(GameObject target) =>
            _target = null;
    }
}