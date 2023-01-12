using System;
using UnityEngine;

namespace CodeBase.Logic
{
    public class CatapultOperator : MonoBehaviour
    {
        [SerializeField] private Catapult _catapult;
        [SerializeField] private RotateToTarget _rotateToTarget;
        [SerializeField] private Collider _observerCollider;

        public void Activate()
        {
            _observerCollider.enabled = true;
            _catapult.enabled = true;
            _rotateToTarget.enabled = true;
        }

        public void Deactivate()
        {
            _catapult.enabled = false;
            _rotateToTarget.enabled = false;
            _observerCollider.enabled = false;
        }
    }
}