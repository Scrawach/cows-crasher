using CodeBase.CameraLogic;
using UnityEngine;

namespace CodeBase.Ufo
{
    public class UfoAppearanceCutscene : MonoBehaviour
    {
        public Transform Ufo;
        public Vector3 StartPosition;
        public Vector3 TargetPosition;
        public float LandingTime;
        public CameraFollow CameraFollow;

        private float _elapsed;

        public bool IsLanding { get; private set; }

        private void Update()
        {
            Ufo.position = Vector3.Lerp(StartPosition, TargetPosition, _elapsed / LandingTime);
            _elapsed += Time.deltaTime;

            if (_elapsed >= LandingTime) 
                Landing();
        }

        private void Landing()
        {
            IsLanding = true;
            Ufo.position = TargetPosition;
            CameraFollow.Follow(Ufo);
            enabled = false;
        }
    }
}