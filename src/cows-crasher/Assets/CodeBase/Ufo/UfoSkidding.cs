﻿using UnityEngine;

namespace CodeBase.Ufo
{
    public class UfoSkidding : MonoBehaviour
    {
        [SerializeField] private Transform _body;
        [SerializeField] private float _angleDegrees = 30f;
        [SerializeField] private float _speed = 3f;
        
        private Vector3 _currentEulerAngles;
        
        public void Rotate(Vector3 direction)
        {
            _currentEulerAngles += EulerAnglesStep(_currentEulerAngles, direction, _angleDegrees, _speed);
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