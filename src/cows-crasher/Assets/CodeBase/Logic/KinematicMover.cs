using System;
using UnityEngine;

namespace CodeBase.Logic
{
    public class KinematicMover : Mover
    {
        private void Update()
        {
            var moveStep = Speed * Time.deltaTime;
            transform.Translate(Movement * moveStep, Space.World);
        }
    }
}