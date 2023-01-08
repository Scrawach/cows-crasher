using UnityEngine;

namespace CodeBase.Common
{
    public class EndlessRotation : MonoBehaviour
    {
        [SerializeField] 
        private Vector3 _angularSpeed = new Vector3(0, 180, 0);

        private void Update()
        {
            var step = Time.deltaTime * _angularSpeed;
            transform.rotation *= Quaternion.Euler(step);
        }
    }
}