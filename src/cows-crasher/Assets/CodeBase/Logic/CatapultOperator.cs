using UnityEngine;

namespace CodeBase.Logic
{
    public class CatapultOperator : MonoBehaviour
    {
        [SerializeField] private Catapult _catapult;
        [SerializeField] private RotateToTarget _rotateToTarget;

        public void Activate()
        {
            _catapult.enabled = true;
            _rotateToTarget.enabled = true;
        }

        public void Deactivate()
        {
            _catapult.enabled = false;
            _rotateToTarget.enabled = false;
        }
    }
}