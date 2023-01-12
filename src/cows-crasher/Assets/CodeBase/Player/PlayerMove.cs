using CodeBase.Logic;
using CodeBase.Ufo;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private PlayerInput _input;
        [SerializeField] private Mover _mover;
        [SerializeField] private UfoSkidding _skidding;

        private void Update()
        {
            _mover.Move(_input.Axis);
            _skidding.Rotate(_input.Axis);
        }
    }
}