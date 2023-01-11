using CodeBase.Player;
using UnityEngine;

namespace CodeBase.Ufo
{
    public class PlayerInteractRay : MonoBehaviour
    {
        [SerializeField] private UfoRay _ray;

        private PlayerInput _input;

        private void Awake() =>
            _input = new PlayerInput(Camera.main);

        private void Update()
        {
            if (_input.IsInteractButtonPressed() && !_ray.IsActivated)
                _ray.ActivateRay();
            else if (_input.IsInteractButtonPressed() && _ray.IsActivated)
                _ray.DeactivateRay();
        }
    }
}