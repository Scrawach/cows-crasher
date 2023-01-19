using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        public bool IsBlocked;
        
        private Camera _camera;

        private void Awake() =>
            _camera = Camera.main;

        public Vector3 Axis
        {
            get
            {
                if (IsBlocked)
                    return Vector3.zero;

                var horizontal = Input.GetAxis(HorizontalAxis);
                var vertical = Input.GetAxis(VerticalAxis);
                var direction = new Vector2(horizontal, vertical);
                var transformedDirection = _camera.transform.TransformDirection(direction);
                transformedDirection.y = 0;
                return transformedDirection.normalized;
            }
        }

        public bool IsInteractButtonPressed() => 
            !IsBlocked && Input.GetKeyDown(KeyCode.Q);
    }
}