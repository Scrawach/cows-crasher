using CodeBase.Ufo;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerInteractRay : MonoBehaviour
    {
        [SerializeField] private PlayerInput _input;
        [SerializeField] private UfoRay _ray;

        private void Update()
        {
            if (_input.IsInteractButtonPressed() && !_ray.IsActivated)
                _ray.ActivateRay();
            else if (_input.IsInteractButtonPressed() && _ray.IsActivated)
                _ray.DeactivateRay();
        }
    }
}