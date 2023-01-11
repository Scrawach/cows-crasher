using System;
using UnityEngine;

namespace CodeBase.Logic
{
    [RequireComponent(typeof(Collider))]
    public class Observer : MonoBehaviour
    {
        public event Action<GameObject> Entered;
        public event Action<GameObject> Exited;
        
        private void OnTriggerEnter(Collider other) =>
            Entered?.Invoke(other.gameObject);

        private void OnTriggerExit(Collider other) =>
            Exited?.Invoke(other.gameObject);
    }
}