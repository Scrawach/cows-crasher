using System;
using UnityEngine;

namespace CodeBase.Logic
{
    public class DestroyAfter : MonoBehaviour
    {
        [SerializeField] private float _pauseInSeconds;

        private void Awake() => 
            Destroy(gameObject, _pauseInSeconds);
    }
}