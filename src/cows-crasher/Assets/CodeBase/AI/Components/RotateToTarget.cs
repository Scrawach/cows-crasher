using CodeBase.Turrets;
using UnityEngine;

namespace CodeBase.AI.Components
{
    public class RotateToTarget : TargetHandler
    {
        [SerializeField] private float _rotationSpeed;

        private Transform _target;

        public float AngleToTarget => Quaternion.Angle(transform.rotation, TargetRotation(PositionToLookAt()));
        
        private void Update()
        {
            if (HasTarget()) 
                SmoothRotate();
        }
        
        public override void SetTarget(GameObject target) =>
            _target = target.transform;

        public override void ResetTarget() =>
            _target = null;
        
        private Quaternion SmoothRotate() =>
            transform.rotation = SmoothedRotation(transform.rotation, PositionToLookAt());

        private bool HasTarget() =>
            _target != null;

        private Vector3 PositionToLookAt()
        {
            var positionDelta = (_target.position - transform.position);
            return new Vector3(positionDelta.x, transform.position.y, positionDelta.z);
        }
    
        private Quaternion SmoothedRotation(Quaternion rotation, Vector3 positionToLook) =>
            Quaternion.RotateTowards(rotation, TargetRotation(positionToLook), _rotationSpeed * Time.deltaTime);

        private Quaternion TargetRotation(Vector3 position) =>
            Quaternion.LookRotation(position);
    }
}