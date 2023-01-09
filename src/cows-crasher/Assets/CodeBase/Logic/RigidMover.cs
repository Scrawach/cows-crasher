using UnityEngine;

namespace CodeBase.Logic
{
    public class RigidMover : Mover
    {
        [SerializeField] private Rigidbody _body;

        private void FixedUpdate() =>
            _body.velocity = Movement * Speed;
    }
}