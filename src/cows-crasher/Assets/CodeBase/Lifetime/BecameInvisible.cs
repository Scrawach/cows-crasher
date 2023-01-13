using System;
using UnityEngine;

namespace CodeBase.Lifetime
{
    public class BecameInvisible : MonoBehaviour
    {
        public event Action OutOfScreen;

        private void OnBecameInvisible() =>
            OutOfScreen?.Invoke();
    }
}