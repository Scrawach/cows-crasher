using UnityEngine;

namespace CodeBase.AI.Components
{
    public class PatrolRoute : MonoBehaviour
    {
        public Transform[] Points;

        private int _goalIndex = -1;

        public Vector3 NextGoal()
        {
            _goalIndex++;

            if (_goalIndex >= Points.Length)
                _goalIndex = 0;

            return Points[_goalIndex].position;
        }
    }
}