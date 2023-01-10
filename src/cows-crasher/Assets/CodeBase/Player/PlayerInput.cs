using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerInput
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        private readonly Camera _camera;

        public PlayerInput(Camera camera) => 
            _camera = camera;

        public bool IsBlocked;

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
            !IsBlocked && Input.GetKey(KeyCode.Q);
    }
}