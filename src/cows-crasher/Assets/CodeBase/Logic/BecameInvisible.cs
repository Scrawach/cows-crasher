using System;
using UnityEngine;

namespace CodeBase.Logic
{
    public class BecameInvisible : MonoBehaviour
    {
        public event Action OutOfScreen;

        private void OnBecameInvisible() =>
            OutOfScreen?.Invoke();
    }
}