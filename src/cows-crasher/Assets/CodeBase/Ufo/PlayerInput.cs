﻿using UnityEngine;

namespace CodeBase.Ufo
{
    public class PlayerInput
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        private readonly Camera _camera;

        public PlayerInput(Camera camera) => 
            _camera = camera;

        public Vector3 Axis
        {
            get
            {
                var horizontal = Input.GetAxis(HorizontalAxis);
                var vertical = Input.GetAxis(VerticalAxis);
                var direction = new Vector2(horizontal, vertical);
                var transformedDirection = _camera.transform.TransformDirection(direction);
                transformedDirection.y = 0;
                return transformedDirection.normalized;
            }
        }

        public bool IsInteractButtonPressed() => 
            Input.GetKey(KeyCode.Space);
    }
}