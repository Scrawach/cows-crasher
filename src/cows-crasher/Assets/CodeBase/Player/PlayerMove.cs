using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] 
        private Mover _mover;
        
        private PlayerInput _input;

        private void Awake() => 
            _input = new PlayerInput(Camera.main);

        private void Update() =>
            _mover.Move(_input.Axis);
    }
}