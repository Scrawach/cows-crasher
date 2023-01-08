using UnityEngine;

namespace CodeBase.Ufo
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] 
        private float _speed = 3f;
        
        private PlayerInput _input;

        private void Awake() => 
            _input = new PlayerInput(Camera.main);

        private void Update() => 
            Move(to: _input.Axis, with: _speed);

        private void Move(Vector3 to, float with)
        {
            var moveStep = with * Time.deltaTime;
            var movement = moveStep * to;
            transform.Translate(movement, Space.World);
        }
    }
}