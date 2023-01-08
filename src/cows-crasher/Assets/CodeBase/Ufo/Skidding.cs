using UnityEngine;

namespace CodeBase.Ufo
{
    public class Skidding : MonoBehaviour
    {
        [SerializeField] 
        private Transform _body;

        [SerializeField] 
        private float _angleDegrees = 30f;

        [SerializeField] 
        private float _speed = 3f;
        
        private PlayerInput _input;

        private Vector3 _currentEulerAngles;
        
        private void Awake() => 
            _input = new PlayerInput(Camera.main);

        private void Update()
        {
            _currentEulerAngles += EulerAnglesStep(_currentEulerAngles, _input.Axis, _angleDegrees, _speed);
            _body.localEulerAngles = _currentEulerAngles;
        }

        private static Vector3 EulerAnglesStep(Vector3 start, Vector3 direction, float degrees, float speed)
        {
            var differenceBetween = DesiredEulerAngles(direction, degrees) - start;
            var timeStep = Time.deltaTime * speed;
            return differenceBetween * timeStep; 
        }

        private static Vector3 DesiredEulerAngles(Vector3 direction, float degrees) => 
            degrees * new Vector3(direction.z, 0f, -direction.x);
    }
}